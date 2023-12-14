using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleTCPServer
{
    internal class Server
    {
        private static TcpListener server;

        private static int clientIndex;

        static void Main(string[] args)
        {
            server = new TcpListener(IPAddress.Any, 6666);
            server.Start();

            Console.WriteLine("Server started ...");

            while (true)
            {
                Console.WriteLine("Waiting on connection ...");

                var client = server.AcceptTcpClient(); // Blocking call der venter på client connecter

                ThreadPool.QueueUserWorkItem(HandleClient, client); // ThreadPool for all clients
            }
        }

        private static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            try
            {
                NetworkStream stream = client.GetStream();

                WriteMessage(stream, "Welcome to the server");

                Client clients = new Client(clientIndex.ToString());
                clientIndex++;

                while (true)
                {
                    if (stream.DataAvailable)
                    {
                        string message = ReadMessage(stream, clients);

                        Respond(stream, clients, message);

                        if (message.ToUpper() == "QUIT")
                        {
                            break;
                        }
                        else
                        {
                            Thread.Sleep(100); // Sparer på ressoucer
                        }

                        if (!stream.CanRead)
                        {
                            break; // If there is nothing to read from stream (or not possible)
                        }
                    }
                }

            }
            finally
            {
                client.Close(); // Slukker client
            }
        }

        /// <summary>
        /// Sends and echos messages back to client
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="custor"></param>
        /// <returns></returns>
        private static string ReadMessage(NetworkStream stream, Client clients)
        {
            byte[] data = new byte[256];

            int bytesRead = stream.Read(data, 0, data.Length);

            if (bytesRead > 0) // if stream has any content
            {
                string clientData = Encoding.ASCII.GetString(data, 0, bytesRead);

                Console.WriteLine($"Recieved: {clientData} from {clients.Name}");

                return clientData;
            }

            return string.Empty;
        }

        /// <summary>
        /// Chooses action based on client/customer input
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="clients"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Respond(NetworkStream stream, Client clients, string input)
        {
            if (input.ToUpper() == "LIST") // Example of list input
            {
                string itemList = string.Empty;

                itemList += "Write buy;item to buy something";

                //foreach (var item in items)
                //{
                //    itemList += "\n" + item.Name; // Adds name of each item to one string
                //}

                WriteMessage(stream, itemList);
            }

            if (input.Contains(" "))
            {
                // Empty input
            }

            if (input.Contains("quit"))
            {
                return "Quit";
            }

            return string.Empty;
        }

        /// <summary>
        /// Sends message to client
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="customer"></param>
        /// <param name="message"></param>
        private static void WriteMessage(NetworkStream stream, string message)
        {
            // Encodes string to bytes to send
            byte[] responseData = Encoding.UTF8.GetBytes(message);

            // Writes data to the stream to send to client, uses byte arrray, 0 offset and length of array
            stream.Write(responseData, 0, responseData.Length);
            Console.WriteLine($"Sending: {message}");
        }
    }
}