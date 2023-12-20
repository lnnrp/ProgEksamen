using System.Diagnostics;

namespace Monitors
{
    internal class Program
    {
        // State is a shared ressource between threads
        private static int state = 5;

        // Creation of lock object the monitor is going to use
        private static object lockObj = new object();

        static void Main(string[] args)
        {
            // Creates and starts two new threads
            for (int i = 0; i < 2; i++)
            {
                Thread t = new Thread(RunMe);
                t.Start();
            }
        }

        /// <summary>
        /// Method that the threads run
        /// </summary>
        private static void RunMe()
        {
            int i = 0; // Used to keep track of when the race condition happens

            while (true)
            {
                // Marks the start of the critical region, only one thread can enter
                // Is an 'expansion' of the 'lock' keyword, as locks are implemented via Monitor
                Monitor.Enter(lockObj);

                if (state == 5) // Checks if state is equal to five
                {
                    state++; // Counts state, the shared resource, up by one
                    Trace.Assert(state == 6, "Race condition in loop: " + i); // Checks if state == 6, if not it displays the message in callstack
                }

                state = 5; // Resets the state variable
                i++; // Counts each loop

                // Marks the end of the critical region
                Monitor.Exit(lockObj);
            }
        }
    }
}