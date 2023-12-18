namespace ObjectPool
{
    internal class Program
    {
        static private VinylObjectPool vinylPool = new VinylObjectPool();
        static private Vinyl
            LYTearVinyl = new Vinyl("Love Yourself: Tear by BTS"),
            RumoursVinyl = new Vinyl("Rumours by Fleetwood Mac"),
            ThroughLoveVinyl = new Vinyl("through love by HYUKOH"),
            WastelandVinyl = new Vinyl("Wasteland, Baby! by Hozier");

        static void Main(string[] args)
        {
            // Populating active/inactive list for test purposes
            vinylPool.Active.Add(LYTearVinyl);
            vinylPool.Active.Add(RumoursVinyl);
            vinylPool.Inactive.Push(ThroughLoveVinyl);
            vinylPool.Inactive.Push(WastelandVinyl);

            Console.WriteLine("The current Vinyls in the Active list\n");

            // Writes the active list to the console
            foreach(Vinyl vn in vinylPool.Active)
            {
                Console.WriteLine(vn.Name);
            }

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("The Active list after releasing the object from it\n");

            // Releases ine vinyl and gets a new one from the inactive stack
            vinylPool.ReleaseObject(LYTearVinyl);
            vinylPool.ReleaseObject(RumoursVinyl);

            foreach(Vinyl vn in vinylPool.Active)
            {
                Console.WriteLine(vn.Name);
            }

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("The Active list after emptying out Inactive stack and calling CreateObject on VinylObjectPool");

            // Emtpies out inactive stack to show VinylObjectPools CreateObject method
            vinylPool.GetObject();
            vinylPool.GetObject();
            vinylPool.GetObject();
            vinylPool.GetObject();
            vinylPool.GetObject();

            foreach (Vinyl vn in vinylPool.Active)
            {
                Console.WriteLine(vn.Name);
            }
        }
    }
}