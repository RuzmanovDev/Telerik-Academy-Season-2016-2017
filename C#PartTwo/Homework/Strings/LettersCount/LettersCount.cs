namespace LettersCount
{
    using System;
    using System.Collections.Generic;

    class LettersCount
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> countOfLetter = new Dictionary<char, int>();
            foreach (var symbol in text)
            {
                if (!countOfLetter.ContainsKey(symbol))
                {
                    countOfLetter.Add(symbol, 1);
                }
                else
                {
                    countOfLetter[symbol]++;
                }
            }

            foreach (KeyValuePair<char,int> count in countOfLetter)
            {
                Console.WriteLine(count);
            }
        }
    }
}