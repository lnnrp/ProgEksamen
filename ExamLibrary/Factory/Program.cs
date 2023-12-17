namespace Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Instantiates the factories");

            // Array using polymorphy 
            VinylFactory[] vinylFactories = new VinylFactory[2]
            {
                new RumoursFactory(),
                new LYTearFactory()
            };

            Console.WriteLine("\nCall create on each factory");

            foreach (VinylFactory factory in vinylFactories)
            {
                factory.CreateVinyl();
            }

            Console.ReadLine();
        }
    }
}