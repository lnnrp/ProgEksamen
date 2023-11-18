using System.Net;
using System.Net.Sockets;
using System.Text;

// UDP - User Datagram Protocol

// The port to connect to
int serverPort = 7777;

// Instantiates new client that listens on port 7777
UdpClient udpClient = new UdpClient(serverPort);

// Parses localhost ip to IPAddress type to use as parameter in clientEndPoint
IPAddress serverIP = IPAddress.Parse("localhost");

// Makes the IP endpoint to be able to send data to server
IPEndPoint serverEndPoint = new IPEndPoint(serverIP, serverPort);

// Connects to the server 
udpClient.Connect(serverEndPoint);

Thread recieveThread = new Thread(() => ReceiveMessagesThread());
recieveThread.IsBackground = true;
recieveThread.Start();

Console.WriteLine("Send a message to the server: ");

// Client update loop for sending messages to server
while (true)
{
    string message = Console.ReadLine();
    byte[] sendData = Encoding.ASCII.GetBytes(message);
    udpClient.Send(sendData);
}


void ReceiveMessagesThread()
{
    // Update loop to recieve messages from server
    while (true)
    {
        // Recieve method to get data from server, need endpoint to know what ip/port to listen on
        // Returns a datagram as a byte array
        byte[] bytes = udpClient.Receive(ref serverEndPoint);

        // Decode the byte array to a string
        string message = Encoding.ASCII.GetString(bytes);

        // Writes the servers message to the console
        Console.WriteLine("From server: " + message);
    }
}
