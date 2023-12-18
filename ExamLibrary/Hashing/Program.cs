using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password;

            Console.WriteLine("Type in a password ... ");
            password = Console.ReadLine();

            string hashPassword = HashPassword(password);
            Console.WriteLine($"The hash password: {hashPassword}\n");

            Console.WriteLine("Now type in the same password ...");
            // Checks if the saved hash matches the entered new password that is hashed
            if (hashPassword == HashPassword(Console.ReadLine()))
            {
                Console.WriteLine("The password is correct, you are logged in");
            }
            else
            {
                Console.WriteLine("The password is correct, you are logged in");
            }
        }

        private static string HashPassword(string? password)
        {
            // Hash function that uses 256 bit
            // Is deterministic, always the same result
            SHA256 sha = SHA256.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(password);

            byte[] hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}