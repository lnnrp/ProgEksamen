namespace ThreadPools
{
    // Not written by me :)
    internal class Program
    {
        private static int minT;
        private static int maxT;
        private static int availT;
        private static int comp;
        private static readonly Random rand = new Random();

        static void Main(string[] args)
        {
            ThreadPool.GetMaxThreads(out maxT, out comp);
            ThreadPool.GetMinThreads(out minT, out comp);
            ThreadPool.GetAvailableThreads(out availT, out comp);

            // Shows the amount of available threads in the threadpool
            Console.WriteLine("Available Threads from the ThreadPool: " + availT);

            // Shows the maximum number of threads that can be active at the same time
            Console.WriteLine("The maximum numberr of threads that can be active: " + maxT);
            // Shows the minimum numberr of threads that is created on demand
            Console.WriteLine(" The Minimum number of threads that is created on demand: " + minT);

            // Adds 10 iterations of ThreadWorkLoop method to the queue to be run by the threadpool threads
            Console.WriteLine("Starting 10 threads running 'ThreadWorkLoop' method");
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadWorkLoop);
            }
            Console.ReadKey();
        }

        // The method that is run 10 times by the threadpool threads
        private static void ThreadWorkLoop(object obj)
        {

            int count = 0;
            int countEnd = rand.Next(20);
            Console.WriteLine("Thread in use. It will release after count hits: " + countEnd);
            while (true)
            {
                if (count >= countEnd)
                {
                    Console.WriteLine("Thread Released");
                    GetAvailableThreads();
                    break;
                }
                Thread.Sleep(400);
                count++;
            }
        }

        // Method for showing amount of available threads
        static void GetAvailableThreads()
        {
            ThreadPool.GetAvailableThreads(out availT, out comp);
            Console.WriteLine("available Threads: " + (availT + 1));
        }
    }
}