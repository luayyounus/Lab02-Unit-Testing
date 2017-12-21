using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeCracker
{
    public class Program
    { 
        static string Decrypt(string message, Dictionary<char, char> decryptionDict)
        {
            string messageDecrypted = "";
            foreach (char c in message.ToLower())
            {
                messageDecrypted += decryptionDict[c];
            }
            return messageDecrypted;
        }

        static string Encrypt(string message, Dictionary<char, char> decryptionDict)
        {
            string messageEncrypted = "";
            foreach (char c in message.ToLower())
            {
                messageEncrypted += decryptionDict.FirstOrDefault(x => x.Value == c).Key;
            }
            return messageEncrypted;
        }

        static void Main(string[] args)
        {
            char[] decryptionCode = { '!', ')', '"', '(', '£', '*', '%', '&', '>', '<', '@', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            Dictionary<char, char> decryptionDict = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                decryptionDict[decryptionCode[i]] = Char.ToLower(alphabet[i]);
            }

            string message = "luay";
            string encryptedMessage = Encrypt(message, decryptionDict);
            Console.WriteLine($" Original Message: {message} - Encrypted Message: {encryptedMessage} \n");

            string decryptedMessage = Decrypt(encryptedMessage, decryptionDict);
            Console.WriteLine($" Encrypted Message: {encryptedMessage} - Cracked Message: {decryptedMessage} \n");
            Console.ReadLine();
        }
    }
}
