namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class MagicWords
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();

            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }

            for (int i = 0; i < words.Count; i++)
            {
                string currentWord = words[i];

                int position = (currentWord.Length % (n + 1));
                words[i] = null;
                words.Insert(position, currentWord);
                words.Remove(null);
            }
            var sorted = words.OrderBy(w => w.Length);
            var longest = sorted.LastOrDefault();


            StringBuilder result = new StringBuilder();
            int maxLength = words.Max(x => x.Length);
         

            for (int i = 0; i < maxLength; i++)
            {
                foreach (var word in words)
                {
                    if (word.Length > i)
                    {
                        result.Append(word[i]);
                    }
                }

            }
            Console.WriteLine(result.ToString());
        }

    }
}

