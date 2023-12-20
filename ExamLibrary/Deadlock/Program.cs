namespace Deadlock
{
    internal class Program
    {
        private static object lockObj1 = new object();
        private static object lockObj2 = new object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Method1);
            Thread thread2 = new Thread(Method2);

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Both threads have started their work!");
        }

        private static void Method1()
        {
            // Locks region with the first lock
            lock (lockObj1)
            {
                Console.WriteLine("Thread 1 used lock object 1");

                Thread.Sleep(100); // Sleep thread for bigger chance of deadlock occuring

                Console.WriteLine("Thread 1 waiting for lock object 2 to be released");
                // Locks region using second lock, which is already in use by thread 2
                lock (lockObj2)
                {
                    Console.WriteLine("Thread 1 locked lock object 2");
                }

            }
        }

        private static void Method2()
        {
            // Locks region with the second lock
            lock (lockObj2)
            {
                Console.WriteLine("Thread 2 used lock object 2");

                Thread.Sleep(100); // Sleep thread for bigger chance of deadlock occuring

                Console.WriteLine("Thread 2 waiting for lock object 1 to be released");
                
                // Locks region using first lock, which is already in use by thread 1
                lock (lockObj1)
                {
                    Console.WriteLine("Thread 2 locked lock object 1");
                }

            }
        }
       
    }
}