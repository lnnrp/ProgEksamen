namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creates two new different events
            Event event1 = new Event("Ganondorf is back!");
            Event event2 = new Event("The mastersword has been found!");

            // Adds two new users (with IListener interface)
            User user1 = new User("Link");
            User user2 = new User("Zelda");

            Console.WriteLine("\n--------- \n");

            // Attaches both users to first event
            event1.Attach(user1);
            event1.Attach(user2);

            // Only attaches first user to second event
            event2.Attach(user1);

            // Calls notify for both events
            event1.Notify();
            event2.Notify();
        }
    }
}