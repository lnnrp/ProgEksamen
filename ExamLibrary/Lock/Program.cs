﻿using System.Diagnostics;

namespace Lock
{
    internal class Program
    {
        // Object for the lock to stop race condition
        // Is static so its guaranteed all threads use same instance
        // Is readonly so it cant be changed
        private static readonly object lockObj = new object();

        // State is a shared ressource between threads
        private static int state = 5;

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
                // Makes sure only one thread has access to the 'critical region'
                // Threads waiting to access the region gets blocked (they're sleeping and dont use CPU resources)
                // Lock internally uses monitor syncronizationmechanism
                lock (lockObj)
                {
                    if (state == 5) // Checks if state is equal to five
                    {
                        state++; // Counts state, the shared resource, up by one
                        Trace.Assert(state == 6, "Race condition in loop: " + i); // Checks if state == 6, if not it displays the message in callstack
                    }

                    state = 5; // Resets the state variable
                    i++; // Counts each loop
                }
            }
        }
    }
}