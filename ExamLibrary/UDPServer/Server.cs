using System.Net;
using System.Net.Sockets;
using System.Text;

// Port that we connect to
int port = 7777;

// UDPClient for server sat to listen to the selected port, same as client
UdpClient udpServer = new UdpClient(port);

while (true)
{
    // IP/port connection to send data to, is set to any so everyone listening on the port can "connect"
    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

    // Recieve data from the client
    byte[] bytes = udpServer.Receive(ref clientEndPoint);

    string message = Encoding.ASCII.GetString(bytes);

    Console.WriteLine("From client: " + message);

    // Server echos client message
    SendMessage(" Server recieved following message from client: " + message, clientEndPoint);



}

void SendMessage(string message, IPEndPoint clientEndPoint)
{
    byte[] sendData = Encoding.ASCII.GetBytes(message);

    // Sends message back to client
    udpServer.Send(sendData, clientEndPoint);
}

