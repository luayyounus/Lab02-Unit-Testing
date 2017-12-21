using System;
using System.Collections.Generic;

namespace CodeCracker
{
    class Program
    { 
        static void Crack(string message, Dictionary<char, char> decryptionDict)
        {
            string messageCracked = "";
            foreach (char c in message.ToLower())
            {
                messageCracked += decryptionDict[c];
            }

            Console.WriteLine($"Original Message: {message} - Cracked Message: {messageCracked} \n");
        }

        static void Main(string[] args)
        {
            char[] decryptionCode = { '!', ')', '"', '(', '£', '*', '%', '&', '>', '<', '@', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            Dictionary<char, char> decryptionCodeDict = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                decryptionCodeDict[decryptionCode[i]] = Char.ToLower(alphabet[i]);
            }

            Crack("aj!n", decryptionCodeDict);
            Console.Read();
        }
    }
}
