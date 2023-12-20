namespace Starvation
{
    internal class Program
    {
        private static object lockObj = new object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => RunMe("Thread 1 is working"));
            Thread thread2 = new Thread(() => RunMe("Thread 2 is working"));

            thread1.Start();
            thread2.Start();

            Console.ReadKey();
        }

        private static void RunMe(object message)
        {
            // Both threads are accessing same method with the same lock
            // Results in one of them not getting their work done thus being starved
            lock (lockObj)
            {
                while (true)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}