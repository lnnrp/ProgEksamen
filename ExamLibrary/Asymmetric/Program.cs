using System.Security.Cryptography;
using System.Text;

namespace Asymmetric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 'Create' method ensures we get recommended implementation of RSA based on the current platform
            // We aren't bound to specific implementation of RSA
            using (RSA rsa = RSA.Create()) 
            {
                // Message to be encrypted/decrypted
                string message = "This is a secret message (shhhh)";

                // Generate a private and public key 
                RSAParameters privateKey = rsa.ExportParameters(false);
                RSAParameters publicKey = rsa.ExportParameters(true);

                Console.WriteLine("Original message: " + message);
                
                for(int i = 0; i < 5; i++)
                {
                    // Calls encrypt/decrypt on the original message
                    byte[] encryptedData = EncryptData(message, privateKey);
                    string decryptedData = DecryptData(encryptedData, publicKey);

                    Console.WriteLine("Encrypted message: " + Convert.ToBase64String(encryptedData)); // Converts the encrypted message to string
                    Console.WriteLine("Decrypted message: " + decryptedData);
                }
               
            }
        }

        /// <summary>
        /// Encrypts the given message with the private key
        /// </summary>
        /// <param name="message"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        private static byte[] EncryptData(string message, RSAParameters privateKey)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(message);

            using (RSA rsa = RSA.Create()) // New RSA object as this method technically could be in another scope (is not here for simplicity
            {
                // Import the key to actually be able to encrypt data
                rsa.ImportParameters(privateKey);

                // Makes use of a Padding algorithm to encrypt the data. 
                // PKCS specifically is non-deterministic, which means that if the same message gets encrypted it results in a new ciphertext
                return rsa.Encrypt(byteData, RSAEncryptionPadding.Pkcs1); 
            }

        }

        /// <summary>
        /// Decrypts the encrypted message using the public key
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        private static string DecryptData(byte[] encryptedData, RSAParameters publicKey)
        {
            using(RSA rsa = RSA.Create())
            {
                // Imports the publickey used for decryption
                rsa.ImportParameters(publicKey);

                byte[] decryptedData = rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(decryptedData);
                   
            }
        }

        
    }
}