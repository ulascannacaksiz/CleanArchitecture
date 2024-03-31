using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public class Program
{
    public static void Main()
    {
        string secret = "mysmallkey1234551298765134567890"; //encryption secret
        byte[] key = Encoding.UTF8.GetBytes(secret);
        byte[] iv = new byte[16];  // 16-byte initialization vector
        new Random().NextBytes(iv); // randomize the IV

        string plainText = "Testtt"; //Text to encode
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

        byte[] cipherBytes = Encrypt(plainBytes, key, iv);
        string cipherText = Convert.ToBase64String(cipherBytes);
        Console.WriteLine("Cipher Text: " + cipherText);
        Console.WriteLine("Key: " + Convert.ToBase64String(key));
        Console.WriteLine("IV: " + Convert.ToBase64String(iv));

        byte[] decryptedBytes = Decrypt(cipherBytes, key, iv);
        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
        Console.WriteLine("Decrypted Text: " + decryptedText);

        Console.ReadLine();
    }

    static byte[] Encrypt(byte[] plainBytes, byte[] key, byte[] iv)
    {
        byte[] encryptedBytes = null;

        // Set up the encryption objects
        using (Aes aes = Aes.Create())
        {
            aes.BlockSize = 128;
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Encrypt the input plaintext using the AES algorithm
            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }
        }

        return encryptedBytes;
    }

    static byte[] Decrypt(byte[] cipherBytes, byte[] key, byte[] iv)
    {
        byte[] decryptedBytes = null;

        // Set up the encryption objects
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Decrypt the input ciphertext using the AES algorithm
            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            {
                decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            }
        }

        return decryptedBytes;
    }
}