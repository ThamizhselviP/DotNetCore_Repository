using RSAEncryptionDecryption;
using System;

class Program
{
    static void Main()
    {
        string message = "Hello RSA Encryption in .NET Core!";

        // Generate RSA Key Pair
        var (publicKey, privateKey) = RSAHelper.GenerateKeys();

        Console.WriteLine("Public Key:");
        Console.WriteLine(publicKey +"\n");

        Console.WriteLine("Private Key:");
        Console.WriteLine(privateKey + "\n");

        // Encrypt using PUBLIC key
        string encrypted = RSAHelper.Encrypt(message, publicKey);
        Console.WriteLine($"Encrypted: {encrypted} \n");

        // Decrypt using PRIVATE key
        string decrypted = RSAHelper.Decrypt(encrypted, privateKey);
        Console.WriteLine($"Decrypted: {decrypted} \n");
    }
}