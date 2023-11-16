using MessagePack;
using System.Net.Sockets;
using TCPClient;

// This TCP client/server is not just bare minimum function. As it's likely only text data will be used a StreamReader would have been enough
// However a BinaryReader is more flexible as that is able to handle other data because it reads the binary directly
// The BinaryWriter uses a length indicator which is more flexible and robust than delimiter (ie \n meaning new line) that would be used by StreamWriter
// Binary reader/writer could be expanded with a messageType, however MessagePack union is able to differentiate between different types of messages and their data on its own


// Connection to server from the clients side
TcpClient client = new TcpClient();

// Connects on PCs own IPAdress, on the same port as server
client.Connect("localhost", 7777);

Console.WriteLine("Connected to server on port 7777 ... ");

// Thread to recieve messages from server, ie "echos" of  actions performed by server
Thread recieveThread = new Thread(() => RecieveMessages(client));
recieveThread.IsBackground = true;
recieveThread.Start();

// Serializes data in binary format 
BinaryWriter bnW = new BinaryWriter(client.GetStream());

// Asks for users name, not necessary but improves readability in examples
Console.WriteLine("Please enter a username ... ");
string name = Console.ReadLine();

SendMessages(new NameMessage() { Name = name});


// Loop for client inputs
while (true)
{
    // Blocking call to avoid infinite loop
    string message = Console.ReadLine();
    SendMessages(new StringMessage() { Message = message });
}


void RecieveMessages(TcpClient client)
{
    // Is able to read data send from the server
    BinaryReader bnR = new BinaryReader(client.GetStream());

    while (client.Connected)
    {
        int messageLength = bnR.ReadInt32();
        byte[] messagBytese = bnR.ReadBytes(messageLength);

        // Able to deserialize the correct type on it's own, so there's no need to send with bnW
        NetworkMessage mes = MessagePackSerializer.Deserialize<NetworkMessage>(messagBytese);
        
        switch (mes)
        {
            case StringMessage stringMes: // Message from server, other types are not necessarily relevant
                Console.WriteLine(stringMes.Message);
                break;
        }
    }
}


void SendMessages(NetworkMessage message)
{
    // MessagePack Union removes need for specifying type of message, ie name/normal chat message/direct chat message
    byte[] messageBytes = MessagePackSerializer.Serialize(message);

    // Sends the length of the message, used when server has to deserialize data
    bnW.Write(messageBytes.Length);
    bnW.Write(messageBytes);

    bnW.Flush();
    
}