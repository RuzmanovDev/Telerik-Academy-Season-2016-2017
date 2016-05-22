using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractSentences
{
    class ExtractSentences
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string sentences = ExtractSentencesContainingGivenWord(word, text);
            Console.WriteLine(sentences);
        }

        private static string ExtractSentencesContainingGivenWord(string word, string text)
        {
            StringBuilder sentences = new StringBuilder();

            var seperateSentences = text.Split('.');

            char[] separator = text.Where(x => !char.IsLetter(x) && x != '.') // Add separator if it is not a letter or '.'.
                             .Distinct() // Remove repeated characters.
                             .ToArray(); // Add separators in array.

            for (int i = 0; i < seperateSentences.Length; i++)
            {
                string currentSentence = seperateSentences[i];
               

                var splittedCurrentSentence = currentSentence.Split(separator);
                foreach (var wordInSentence in splittedCurrentSentence)
                {
                    if (word == wordInSentence)
                    {
                        sentences.Append(currentSentence);
                        sentences.Append('.');
                        break;
                    }
                }
            }

            return sentences.ToString();
        }
    }
}
