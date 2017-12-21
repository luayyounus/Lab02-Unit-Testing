using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeCracker
{
    public class Message
    {
        public static string Encrypt(string message)
        {
            Dictionary<char, char> decryptionDict = CreateDecryptionDictionary();
            string messageEncrypted = "";
            foreach (char c in message.ToLower())
            {
                messageEncrypted += decryptionDict.FirstOrDefault(x => x.Value == c).Key;
            }
            return messageEncrypted;
        }

        public static string Decrypt(string message)
        {
            Dictionary<char, char> decryptionDict = CreateDecryptionDictionary();
            string messageDecrypted = "";
            foreach (char c in message.ToLower())
            {
                messageDecrypted += decryptionDict[c];
            }
            return messageDecrypted;
        }

        public static Dictionary<char, char> CreateDecryptionDictionary()
        {
            char[] decryptionCode = { '!', ')', '"', '(', '£', '*', '%', '&', '>', '<', '@', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', ' ' };
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };

            Dictionary<char, char> decryptionDict = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                decryptionDict[decryptionCode[i]] = Char.ToLower(alphabet[i]);
            }
            return decryptionDict;
        }

        static void Main(string[] args)
        {
            string message = "This challenge is not so challenging";
            string encryptedMessage = Encrypt(message);
            Console.WriteLine($" Original Message: {message} - Encrypted Message: {encryptedMessage} \n");

            string decryptedMessage = Decrypt(encryptedMessage);
            Console.WriteLine($" Encrypted Message: {encryptedMessage} - Cracked Message: {decryptedMessage} \n");
            Console.ReadLine();
        }
    }
}
