using System.Security.Cryptography;
using System.Text;

namespace SaltHashingWithDB
{
    /// <summary>
    /// Eksempel fra undervisning (Emil)
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Is used instead of a database, consists of a string (the password), and a tuple of the hash and salt
        /// A tuple groups multiple data elements in a lightweight data structure.
        /// </summary>
        private static Dictionary<string, (byte[] passHash, byte[] salt)> fakeDB = new Dictionary<string, (byte[] passHash, byte[] salt)>();

        static void Main(string[] args)
        {
            AddUser("Mario", "ItsaMeMario");
            AddUser("Link", "MasterswordTriforce");
            AddUser("Sonic", "GottaGoFast");

            foreach (var kvp in fakeDB)
            {
                Console.WriteLine($"{kvp.Key} has hashedPasswithSalt:" +
                $"{BitConverter.ToString(kvp.Value.passHash).Replace("-", "")}" +
                $" and salt: {BitConverter.ToString(kvp.Value.salt).Replace("-", "")} ");
            }

            ValidateUser("Mario", "ItsaMeMario");
            ValidateUser("Sonic", "GottaGoFast");

        }

        private static void AddUser(string userName, string userPass)
        {
            // Byte array for salt with a given size
            byte[] salt = new byte[16];
            
            // Puts into array + RNGCryptoServiceProvider is obsolete
            RandomNumberGenerator rng = RandomNumberGenerator.Create(); 
           
            // Fills salt array using the RNG
            rng.GetBytes(salt);
            
            // Uses SHA256 as hash function
            SHA256 mySHA256 = SHA256.Create();

            // Byte array for both password and salt
            byte[] PassPlusSalt = Encoding.UTF8.GetBytes(userPass).Concat(salt).ToArray();

            // Hashes the password after its combined with salt
            byte[] hashedPassWithSalt = mySHA256.ComputeHash(PassPlusSalt);

            // Adds user to 'database'
            fakeDB.Add(userName, (hashedPassWithSalt, salt));
        }

        private static bool ValidateUser(string userName, string password)
        {
            // Trys to access database and find user
            if (fakeDB.TryGetValue(userName, out (byte[] passHash, byte[] salt) userInfo))
            {
                byte[] inputPlusSalt = Encoding.UTF8.GetBytes(password).Concat(userInfo.salt).ToArray();
                SHA256 mySHA256 = SHA256.Create();
                byte[] passPlusSaltedHashed = mySHA256.ComputeHash(inputPlusSalt);
                if (passPlusSaltedHashed.SequenceEqual(userInfo.passHash))
                {
                    Console.WriteLine($"{userName} logged in with correct input and password :-)");
                    return true;
                }
            }

            // Gives generic message if either user OR password is incorrect
            // If message is non-generic it would be possible to determine what users 
            Console.WriteLine("incorrect user/password");
            return false;
        }
    }
}