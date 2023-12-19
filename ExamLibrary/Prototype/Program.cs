namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VinylObject originalObject = new VinylObject(7, "through love by HYUKOH", "Special Edition");

            // Make Shallow Clone of the object
            //VinylObject clone = originalObject.ShallowClone();

            // Make Deep Clone of the object
            VinylObject clone = originalObject.DeepClone();

            Console.WriteLine("BEFORE changing the clones values: \n");

            Console.WriteLine("Original: " + originalObject.ObjectNumber);
            Console.WriteLine("Original: " + originalObject.ObjectDescription.Name);
            Console.WriteLine("Original: " + originalObject.ObjectDescription.Description);
            Console.WriteLine("\nClone: " + clone.ObjectNumber);
            Console.WriteLine("Clone: " + clone.ObjectDescription.Name);
            Console.WriteLine("Clone: " + clone.ObjectDescription.Description);

            Console.WriteLine("\n-----------\n");

            // Changes the value type (number)
            clone.ObjectNumber = 666;

            // Changes the reference type (ObjectDescription class)
            clone.ObjectDescription.Name = "Rumours by Fleetwood Mac";
            clone.ObjectDescription.Description = "Standard Edition";

            Console.WriteLine("AFTER changing the clones values: \n");

            Console.WriteLine("Original: " + originalObject.ObjectNumber);
            Console.WriteLine("Original: " + originalObject.ObjectDescription.Name);
            Console.WriteLine("Original: " + originalObject.ObjectDescription.Description);
            Console.WriteLine("\nClone: " + clone.ObjectNumber);
            Console.WriteLine("Clone: " + clone.ObjectDescription.Name);
            Console.WriteLine("Clone: " + clone.ObjectDescription.Description);



        }
    }
}