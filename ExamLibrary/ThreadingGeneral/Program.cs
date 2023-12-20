namespace ThreadingGeneral
{
    internal class Program
    {
        private static bool isAlive;

        static void Main(string[] args)
        {
            Console.WriteLine("This is the main thread");

            // A basic thread that calls a method with no parameters
            Thread myThread = new Thread(ThreadWork);
            myThread.Start();

            // A thread that uses a lambda expression to call a method with parameters
            Thread threadWParams = new Thread(() => ThreadWithParams("This is a threat with parameters"));
            threadWParams.Start();

            // Showcasing how threads 'die' or get closed correctly
            // Since it's an infinite loop, it's sat as a background thread which means it gets killed when the program does
            Thread m1 = new Thread(M1);
            m1.IsBackground = true;
            m1.Start();

            Thread m2 = new Thread(M2);
            m2.Start();

        }


        private static void ThreadWork()
        {
            Console.WriteLine("This is running in a seperate thread");
        }

        private static void ThreadWithParams(string message)
        {
            Console.WriteLine(message);
        }

        private static void M1()
        {
            while (true)
            {
                Console.WriteLine("I'm M1");
                Thread.Sleep(1000);
            }
        }

        private static void M2()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("I'm M2 nr {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}