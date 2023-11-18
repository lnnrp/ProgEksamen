using MessagePack;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TCPServer;

// Collection of all clients connected to server
Dictionary<Guid, string> activeClients = new Dictionary<Guid, string>();

BinaryReader bnR;
BinaryWriter bnW;

// Server is able to connect to any available IPs that are trying to connect via port 7777
// In theory could other computers connect to this server, however in this project it's only this one
TcpListener server = new TcpListener(IPAddress.Any, 7777);

// Server starts listening
server.Start();

Console.WriteLine("Server is listening on port 7777 ...");

// While loop that waits for new clients to connect
while (true)
{
    // Blocking call to avoid infinite while loop, as it only continues when a new client has connected
    TcpClient client = server.AcceptTcpClient();
    Thread clientThread = new Thread(() => HandleClient(client));
    clientThread.Start();
}

void HandleClient(TcpClient client)
{
    // Reader to read stream from client
    // Used instead of StreamReader as that only is able to get text whereas binary just reads binary data
    // Not necessarily applicable here, but if server is to be scalable and has to send non-text data you would need BinaryReader
    bnR = new BinaryReader(client.GetStream());
    bnW = new BinaryWriter(client.GetStream());

    Guid clientId = Guid.NewGuid();

    try
    {
        while (client.Connected)
        {
            // Reads the messageLength first, as we know thats the first thing sent by the client
            int messageLength = bnR.ReadInt32();

            // Reads messageData itself
            byte[] messageBytes = bnR.ReadBytes(messageLength);

            // Deserializes message from binary data to data we can read ie string or int. 
            // Becuase of union it can deserialize the correct type on it's own
            NetworkMessage mes = MessagePackSerializer.Deserialize<NetworkMessage>(messageBytes);

            switch (mes)
            {
                case OnConnectionMessage onConnection:
                    break;
                case NameMessage name:
                    activeClients.Add(clientId, name.Name);
                    Console.WriteLine($"Client {name.Name} connected to server");
                    SendMessageToClient(new StringMessage() { Message = $"SERVER: Hello {name.Name}!" });
                    break;
                case StringMessage stringMes:
                    Console.WriteLine($"{activeClients[clientId]}: {stringMes.Message}" );
                    // Server echos message back to client
                    SendMessageToClient(new StringMessage() { Message = $"SERVER: Recieved message {stringMes.Message}" });
                    break;
                case ExampleMessage ex:
                    // TODO: change to fit specific use
                    break;
                default:
                    Console.WriteLine("Could not recognize message type :(");
                    break;
            }
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Exception occurred for client {activeClients[clientId]}: {ex.Message}");
    }
    finally
    {
        SendMessageToAllClients(new StringMessage() { Message = $"{activeClients[clientId]} has left the server ..."});
        activeClients.Remove(clientId);
    }



}

void SendMessageToClient(NetworkMessage message)
{
    // MessagePack Union removes need for specifying type of message, ie name/normal chat message/direct chat message
    byte[] messageBytes = MessagePackSerializer.Serialize(message);

    // Sends the length of the message, used when server has to deserialize data
    bnW.Write(messageBytes.Length);
    bnW.Write(messageBytes);

    bnW.Flush();
}

void SendMessageToAllClients(NetworkMessage message)
{
    foreach(Guid clientId in activeClients.Keys)
    {
        SendMessageToClient(message);
    }
}
