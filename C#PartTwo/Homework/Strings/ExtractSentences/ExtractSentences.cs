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

            for (int i = 0; i < seperateSentences.Length; i++)
            {
                string currentSentence = seperateSentences[i];
                var seperator = currentSentence.Where(c => !char.IsLetterOrDigit(c)).Select(t => t).ToArray();

                var splittedCurrentSentence = currentSentence.Split(seperator);
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
