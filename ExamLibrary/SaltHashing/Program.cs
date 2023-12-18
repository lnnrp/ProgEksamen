using System.Security.Cryptography;
using System.Text;

namespace SaltHashing
{
    internal class Program
    {
        // Is useful for storing passwords

        static void Main(string[] args)
        {
            string password;
            string salt;

            Console.WriteLine("Type in a password ... ");
            password = Console.ReadLine();
            salt = GetRandomSalt();

            string hashPassword = HashPassword(password, salt);
            Console.WriteLine($"The hash password: {hashPassword}\n");

            Console.WriteLine("Now type in the same password ...");
            // Checks if the saved hash matches the entered new password that is hashed
            if(hashPassword == HashPassword(Console.ReadLine(), salt))
            {
                Console.WriteLine("The password is correct, you are logged in");
            }
            else
            {
                Console.WriteLine("The password is correct, you are logged in");
            }
        }

      
        /// <summary>
        /// Hashes the password
        /// </summary>
        /// <param name="password">The password typed by user</param>
        /// <param name="salt">The salt used to hash the password</param>
        /// <returns>The hash as a string</returns>
        private static string HashPassword(string? password, string salt)
        {
            // Combines the password and salt into one string
            string combinedPassword = string.Concat(password, salt);

            // Hash function that uses 256 bit
            // Is deterministic, always the same result
            SHA256 sha = SHA256.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(combinedPassword);

            byte[] hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Gets a salt
        /// A 'seed' for the hashing, ensures no two passwords would have the same hash
        /// A collection of random numbers and letters
        /// </summary>
        /// <param name="size">How big the salt should be</param>
        /// <returns>The salt as a string</returns>
        private static string GetRandomSalt(int size = 12)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create(); // RNGCryptoServiceProvider is obsolete, this is the new implementation

            // Byte array based on the size given in parameters
            byte[] salt = new byte[size];

            // Fills out the array with random numbers and letters
            rng.GetBytes(salt);

            return Convert.ToBase64String(salt);

        }
    }
}