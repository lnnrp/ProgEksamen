using System.Security.Cryptography;
using System.Text;

namespace Symmetric
{
    internal class Program
    {
        /// <summary>
        /// Initialization Vector
        /// A form of 'Seed' for encrypting messages, encrypts a message differently per IV
        /// Adds randomness to encryption
        /// </summary>
        private static byte[] iv = new byte[16];
        private static RandomNumberGenerator rng = RandomNumberGenerator.Create(); // The given example used RNGCryptoServiceProvider, which is now obsolete

        static void Main(string[] args)
        {
            rng.GetBytes(iv);

            Console.WriteLine("Please enter an encryption key ...");
            byte[] key = SHA256.HashData(Encoding.UTF8.GetBytes(Console.ReadLine()));

            while (true)
            {
                Console.WriteLine("Enter a message to encrypt ...");
                string data = Console.ReadLine(); // Blocking call
                ËncryptAesManaged(data, key, iv);
            }
        }

        private static void ËncryptAesManaged(string? data, byte[] key, byte[] iv)
        {
            try
            {
                //Encrypts string
                byte[] encrypted = Encrypt(data, key, iv);
                Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");

                //Decrypts byte array to string
                string decrypted = Decrypt(encrypted, key, iv);
                Console.WriteLine($"Decrypted data: {decrypted}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static byte[] Encrypt(string? plainText, byte[] key, byte[] iV)
        {
            byte[] encrypted;

            // Advanced Encryption Standard allows both parties (sender/reciever) to use the same key to encrypt and decrypt data
            // Aes object that contains all functions for encrypting using the aes algorithm
            // The example used AesManaged, as that was platform agnostic, however it is now obsolete and Aes.Create() is now the way to call it
            using (Aes aes = Aes.Create())
            {
                // Is used to actually encrypt the data, uses the aes instance and takes the key and iv as parameters
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iV);

                // Acts as a temporary buffer for the encrypted data
                using (MemoryStream ms = new MemoryStream())
                {
                    // CryptroStream connects MemoryStream and the encryptor
                    // Makes it possible to write encrypted data to the MemoryStream
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Instantiates StreamWriter, used to write data to the CryptoStream, the unencrypted data gets written to the stream (plainText)
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);

                        // Converts the MemoryStream to an array that gets saved in encrypted byte array
                        encrypted = ms.ToArray();
                    }
                }
            }

            // Returns encrypted data
            return encrypted;
        }

         static string Decrypt(byte[] cipherText, byte[] key, byte[] iV)
        {
            string plainText = null;

            // Virtually the same as encrypt method
            using (Aes aes = Aes.Create())
            {
                // Creates DEcrypter instead
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iV);

                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // StreamMode is sat to Read instead of write
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                            plainText = sr.ReadToEnd(); // Reads the stream instead of sending to it
                    }
                }
            }

            return plainText;
        }
    }
}