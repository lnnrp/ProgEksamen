using System.Diagnostics;

namespace Mutexes
{
    internal class Program
    {
        // State is a shared ressource between threads
        private static int state = 5;

        // Mutex that gets used to lock on
        // Works across multiple processes (unlike lock/monitor)
        // Can only get released by the thread that recieves the mutex (enforces thread identity) -
        // if the thread using the mutex crashes or gets killed it is abandoned and throws an exception
        private static Mutex m = new Mutex();

        // A mutex can be 'owned' when it is instantiated, can be used to determine when a thread gets activated
        private static Mutex mSpecial = new Mutex(true);

        static void Main(string[] args)
        {
            // Creates and starts two new threads
            for (int i = 0; i < 2; i++)
            {
                Thread t = new Thread(RunMe);
                t.Start();
            }

            // Following is used to show one of the special capabilities of mutex
            //Console.WriteLine("Threads are waiting - Press any key to start them");
            //Console.ReadKey();
            //mSpecial.ReleaseMutex();
        }

        /// <summary>
        /// Method that the threads run
        /// </summary>
        private static void RunMe()
        {
            int i = 0; // Used to keep track of when the race condition happens

            while (true)
            {
                // Marks the start of the critical region
                m.WaitOne();
                //mSpecial.WaitOne();

                if (state == 5) // Checks if state is equal to five
                {
                    state++; // Counts state, the shared resource, up by one
                    Trace.Assert(state == 6, "Race condition in loop: " + i); // Checks if state == 6, if not it displays the message in callstack
                }

                state = 5; // Resets the state variable
                i++; // Counts each loop
                
                // Marks the end of the critical region
                m.ReleaseMutex();
                //mSpecial.ReleaseMutex();
            }
        }
    }
}