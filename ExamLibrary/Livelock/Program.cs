namespace Livelock
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
            while (true)
            {
                Monitor.Enter(lockObj1);
                Console.WriteLine("Thread 1 used lock object 1");

                // Sleep thread for bigger chance of deadlock occuring/simulating work
                Thread.Sleep(100);

                // Thread tries to aquire lock that is held by thread 2
                if (Monitor.TryEnter(lockObj2))
                {
                    Console.WriteLine("Thread 1 acquired lock object 2");
                    Monitor.Exit(lockObj1);
                    break; // Thread has succesfully acquired lock and breaks the while loop
                }
                else
                {
                    Console.WriteLine("Thread 1 released lock 1");
                    // Thread 1 releases the lock
                    Monitor.Exit(lockObj1);
                }

            }

        }

        private static void Method2()
        {
            while (true)
            {
                Monitor.Enter(lockObj2);
                Console.WriteLine("Thread 2 used lock object 2");

                // Sleep thread for bigger chance of deadlock occuring/simulating work
                Thread.Sleep(100);

                // Thread tries to aquire lock that is held by thread 1
                if (Monitor.TryEnter(lockObj1))
                {
                    Console.WriteLine("Thread 2 acquired lock object 1");
                    Monitor.Exit(lockObj2);
                    break; // Thread has succesfully acquired lock and breaks the while loop
                }
                else
                {
                    Console.WriteLine("Thread 2 released lock 2");
                    // Thread 2 releases lock 2
                    Monitor.Exit(lockObj2);
                }

            }
        }
    }
}