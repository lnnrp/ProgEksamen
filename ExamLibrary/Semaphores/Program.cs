namespace Semaphores
{
    internal class Program
    {
        // Semaphore with initial count of 3 and max capacity of 5
        private static Semaphore semaphore = new Semaphore(0, 3);

        static void Main(string[] args)
        {
            for(int i = 0; i <= 5; i++)
            {
                new Thread(Enter).Start(i);
            }

            Thread.Sleep(500); // Main thread sleeps to allow threads to start and block the semaphore
            Console.WriteLine("Main thread calls Release(3) - The Nightclub is open!");
            semaphore.Release(3); // Main thread releases the semaphore
            Console.ReadKey();
        }

        private static void Enter(object id)
        {
            Console.WriteLine(id + " starts and waits outside to enter");

            //Only three threads allowed in at a time
            semaphore.WaitOne(); 
            Console.WriteLine(id + " enters the Nightclub!");
            
            // Is 'active' in the nightclub, this is where functions normally would be
            Thread.Sleep(1000 * (int)id); 

            // Calls release when thread is done working
            Console.WriteLine(id + " is leaving");
            semaphore.Release();
        }
    }
}