using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace AESEncryptionDecryption
{
    public static class EncryptionHelper
    {
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt);

            swEncrypt.Write(plainText);
            swEncrypt.Close();

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));

            byte[] buffer = Convert.FromBase64String(cipherText);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            using MemoryStream msDecrypt = new(buffer);
            using CryptoStream csDecrypt = new(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            return srDecrypt.ReadToEnd();
        }

        public static byte[] GenerateRandomKey(int size = 32) // 32 bytes = 256-bit
        {
            byte[] key = new byte[size];
            RandomNumberGenerator.Fill(key);
            return key;
        }

        public static byte[] GenerateRandomIV()
        {
            byte[] iv = new byte[16]; // AES block size = 16 bytes
            RandomNumberGenerator.Fill(iv);
            return iv;
        }
    }
}
