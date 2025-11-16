using System;
using System.Security.Cryptography;
using System.Text;

namespace CSE445_Assignment5_Stenhouse
{
    public static class CryptoUtils
    {
        // Compute SHA256 hash of a string
        public static string ComputeSHA256(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2")); // hex
                return sb.ToString();
            }
        }

        // Simple AES encryption
        public static string EncryptAES(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // 256-bit
                aes.IV = new byte[16]; // zero IV for simplicity (can improve)
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return Convert.ToBase64String(encrypted);
            }
        }

        // Simple AES decryption
        public static string DecryptAES(string cipherText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
                aes.IV = new byte[16];
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] decrypted = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }
}
