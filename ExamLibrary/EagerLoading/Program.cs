namespace EagerLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            EagerRecordStore recordStore = new EagerRecordStore(); // Vinyls gets loaded in here, as they get called in constructor

            Console.WriteLine("Record store bruger Eager Loading \n");
            Console.WriteLine("Record stores liste af vinyler FØR foreach loop");
            Console.WriteLine(recordStore.vinyls == null ? "There are NOT any vinyls in the store" : "There ARE vinyls in the store"); // The same code as is used for lazy loading, makes for easy comparison

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("Foreach loop gennem 'vinyls' liste");
            foreach(Vinyl vinyls in recordStore.EagerVinyls)
            {
                Console.WriteLine("Title: " + vinyls.Title + ", Released: " + vinyls.Year);
            }

            Console.WriteLine("\n---------------\n");

            Console.WriteLine("Record stores liste af vinyler EFTER foreach loop");
            Console.WriteLine(recordStore.vinyls == null ? "There are NOT any vinyls in the store" : "There ARE vinyls in the store");
        }
    }
}