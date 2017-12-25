using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t Finding Anagrams from the wordlist text file." +
                              "\n\t The operation might take up to 10 seconds." +
                              "\n\t A message will show up when finished.");

            // Reading word list text and storing each line into an index inside a string array
            string[] wordsToCheck = File.ReadAllLines("wordlist.txt");

            // New array with all words sorted ascendingly for later comparison about anagrams
            string[] wordsSorted = new string[wordsToCheck.Length];
            for (int i = 0; i < wordsToCheck.Length; i++)
            {
                char[] wordArray = wordsToCheck[i].Replace("'", "").ToUpper().ToCharArray();
                Array.Sort(wordArray);
                wordsSorted[i] = new string(wordArray);
            }

            // Keeping track of anagrams already printed to output in order to prevent duplicates
            List<string> previouslyPrintedToOutput = new List<string>();

            // Keeping track of anagrams to keep the longest words anagrams available
            int longestWordsAnagramsCount = 0;
            string longestWordsAnagrams = "";

            // Keeping track of the word sets to find the set with most words anagrams
            int setWithMostWordsAnagramsCount = 0;
            string setWithMostWordsAnagrams = "";

            // Creating output file and initializing with empty string.
            using (FileStream fs = File.Create("output.txt"))
            {
                byte[] emptyFile = new UTF8Encoding(true).GetBytes("");
                fs.Write(emptyFile, 0, emptyFile.Length);
            }

            // Appending anagrams to output file
            using (StreamWriter sw = File.AppendText("output.txt"))
            {
                foreach (string word in wordsSorted)
                {
                    // Counter to ckeck if there is at least one anagram for the word in array.
                    int checkIfAtLeastOneAnagramCount = 0;

                    // Calculating a set with most anagrams every iteration to find the set with MOST anagrams
                    int tempSetWithMostAnagramsCount = 0;

                    // String builder to concatinate anagrams with each others into one line
                    StringBuilder sb = new StringBuilder();

                    // Appending anagrams to string builder for later export to output file
                    string tempWord = word;
                    for (int j = 0; j < wordsSorted.Length; j++)
                    {
                        if (tempWord != wordsSorted[j]) continue;
                        checkIfAtLeastOneAnagramCount++;
                        sb.Append(wordsToCheck[j] + " ");
                        tempSetWithMostAnagramsCount++;
                    }

                    // Converting String builder back to a string to print to output
                    string anagramToOutput = sb.ToString();

                    // if the new set has more anagrams than the previous set, then set it to the most anagrams count
                    if (tempSetWithMostAnagramsCount > setWithMostWordsAnagramsCount)
                    {
                        setWithMostWordsAnagramsCount = tempSetWithMostAnagramsCount;
                        setWithMostWordsAnagrams = anagramToOutput;
                    }

                    // Checking if anagrams are found and not already exist in output file in order to add them to the output file
                    if (checkIfAtLeastOneAnagramCount > 1 && !previouslyPrintedToOutput.Contains(anagramToOutput))
                    {
                        sw.WriteLine(anagramToOutput);

                        if (tempWord.Length >= longestWordsAnagramsCount)
                        {
                            longestWordsAnagramsCount = tempWord.Length;
                            longestWordsAnagrams = anagramToOutput;
                        }
                    }

                    // Adding to prev printed to prevent duplicating a print to the output file
                    previouslyPrintedToOutput.Add(anagramToOutput);

                    // Emptying out the string builder every iteration
                    sb.Clear();
                }
            }

            Console.WriteLine("\n----------------------------------------------------------------------------------" +
                              $"\n Longest Words Anagrams: {longestWordsAnagrams}" +
                              $"\n Set with Most Words Anagrams: {setWithMostWordsAnagrams}" +
                              "\n Operation Completed! Check 'output.txt' inside your solution to find Anagarams.\n" +
                              "\n----------------------------------------------------------------------------------");
            Console.Read();
        }
    }
}
