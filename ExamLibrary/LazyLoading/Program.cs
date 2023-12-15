namespace LazyLoading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LazyRecordStore recordStore = new LazyRecordStore(); // Vinyls are null here as they onl
            ImplementedLazyRecordStore implementedRecordStore = new ImplementedLazyRecordStore(); // This uses the implemented version of lazy loading already

            Console.WriteLine("Record store uses Lazy Loading \n");
            Console.WriteLine("Record stores list of vinyls BEFORE foreach loop");
            Console.WriteLine(recordStore.vinyls == null ? "There are NOT any vinyls in the store" : "There ARE vinyls in the store"); // The same code as is used for lazy loading, makes for easy comparison

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("Foreach loop through 'vinyls' list");
            foreach (Vinyl vinyls in recordStore.LazyVinyls)
            {
                Console.WriteLine("Title: " + vinyls.Title + ", Released: " + vinyls.Year);
            }

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("Record stores list of vinyls AFTER foreach loop");
            Console.WriteLine(recordStore.vinyls == null ? "There are NOT any vinyls in the store" : "There ARE vinyls in the store");

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("Record store loading using implemented Lazy class \n"); // Cant do the same test by showing if list is null before, as that "triggers" the loading
            Console.WriteLine("Foreach loop through 'vinyls' list");
            foreach (Vinyl vinyls in implementedRecordStore.LazyVinyls)
            {
                Console.WriteLine("Title: " + vinyls.Title + ", Released: " + vinyls.Year);
            }

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("Record stores list of vinyls AFTER foreach loop");
            Console.WriteLine(implementedRecordStore.vinyls == null ? "There are NOT any vinyls in the store" : "There ARE vinyls in the store");

        }
    }
}