using System;
using System.Text;
using System.Security.Cryptography;

namespace RSAEncryptionDecryption
{
    public static class RSAHelper
    {
        // Generate RSA key pair and return PEM strings
        public static (string publicKey, string privateKey) GenerateKeys(int keySize = 2048)
        {
            using RSA rsa = RSA.Create(keySize);

            string publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
            string privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());

            return (publicKey, privateKey);
        }

        // Encrypt with PUBLIC KEY
        public static string Encrypt(string plainText, string base64PublicKey)
        {
            using RSA rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(base64PublicKey), out _);

            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] encrypted = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);

            return Convert.ToBase64String(encrypted);
        }

        // Decrypt with PRIVATE KEY
        public static string Decrypt(string cipherText, string base64PrivateKey)
        {
            using RSA rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(base64PrivateKey), out _);

            byte[] encrypted = Convert.FromBase64String(cipherText);
            byte[] decrypted = rsa.Decrypt(encrypted, RSAEncryptionPadding.OaepSHA256);

            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
