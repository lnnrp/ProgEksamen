using System.Net.Sockets;
using System.Text;

namespace SimpleTCPClient
{
    internal class Client
    {
        /// <summary>
        /// Bool to close the connection
        /// </summary>
        private static bool run = true;

        static void Main(string[] args)
        {
            string server = "localhost";
            int port = 6666;

            Console.WriteLine("Waiting to connect to server ...");

            using (TcpClient client = new TcpClient(server, port)) // Using statement gør bla at man ikke skal kalde dispose på client
            {
                using (NetworkStream stream = client.GetStream())
                {
                    // Two threads for both writing and reading
                    Thread reader = new Thread(() => ReadMessage(stream));
                    Thread writer = new Thread(() => WriteMessage(stream));

                    reader.Start();
                    writer.Start();

                    reader.Join();
                    writer.Join();
                }
            }
        }

        /// <summary>
        /// Sends message to client
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="customer"></param>
        /// <param name="message"></param>
        private static void WriteMessage(NetworkStream stream)
        {
            while (run)
            {
                string message = Console.ReadLine(); // Blocking call to avoid infinite loop
                // Encodes string to bytes to send
                byte[] data = Encoding.UTF8.GetBytes(message);

                // Writes data to the stream to send to client, uses byte arrray, 0 offset and length of array
                stream.Write(data, 0, data.Length);

                if (message.ToUpper() == "QUIT")
                {
                    run = false;
                }
            }

        }

        private static void ReadMessage(NetworkStream stream)
        {
            while (run)
            {
                if (stream.DataAvailable)
                {
                    byte[] data = new byte[256];

                    int bytesRead = stream.Read(data, 0, data.Length);

                    if (bytesRead > 0)
                    {
                        string responseData = Encoding.ASCII.GetString(data, 0, bytesRead);

                        Console.WriteLine(responseData);
                    }
                    else
                    {
                        Thread.Sleep(100); // Performance
                    }

                    if (!stream.CanRead) 
                    {
                        break;
                    }
                }
            }
        }
    }
}