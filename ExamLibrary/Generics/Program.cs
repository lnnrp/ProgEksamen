namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define variables to be swapped (show it works with different types)
            string firstString = "Link";
            string secondString = "Zelda";

            int firstInt = 5;
            int secondInt = 9;

            bool firstBool = true;
            bool secondBool = false;

            // Print variables before swap
            Console.WriteLine("Before:");
            Console.WriteLine(firstInt + " : " + secondInt);
            Console.WriteLine(firstString + " : " + secondString);
            Console.WriteLine(firstBool + " : " + secondBool);

            // Do swap
            Swap<string>(ref firstString, ref secondString);
            Swap<int>(ref firstInt, ref secondInt);
            Swap<bool>(ref firstBool, ref secondBool);

            // Print variables after swap
            Console.WriteLine("\nAfter:");
            Console.WriteLine(firstInt + " : " + secondInt);
            Console.WriteLine(firstString + " : " + secondString);
            Console.WriteLine(firstBool + " : " + secondBool);
        }

        /// <summary>
        /// Generic swap method, swapping two values of the same type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">First value</param>
        /// <param name="second">Second value</param>
        static void Swap<T>(ref T first, ref T second)
        {
            T tmp = first;
            first = second;
            second = tmp;
        }
    }
}