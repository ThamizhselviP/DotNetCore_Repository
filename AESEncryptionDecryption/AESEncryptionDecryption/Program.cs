using AESEncryptionDecryption;

class Program
{
    static void Main()
    {
        string original = "Hello, this is an important message to keep it secret!";

        // Generate AES-256 Key + IV
        byte[] key = EncryptionHelper.GenerateRandomKey();
        byte[] iv = EncryptionHelper.GenerateRandomIV();

        // Encrypt
        string encrypted = EncryptionHelper.Encrypt(original, key, iv);
        Console.WriteLine($"Encrypted: {encrypted}");

        // Decrypt
        string decrypted = EncryptionHelper.Decrypt(encrypted, key, iv);
        Console.WriteLine($"Decrypted: {decrypted}");
    }
}