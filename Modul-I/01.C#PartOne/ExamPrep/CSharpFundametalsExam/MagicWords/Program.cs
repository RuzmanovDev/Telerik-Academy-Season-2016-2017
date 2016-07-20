using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var input = new List<string>();
            for (int i = 0; i < n; i++)
            {
                input.Add(Console.ReadLine());

            }


            for (int i = 0; i < n; i++)
            {
                var word = input[i];
                int indexToMove = word.Length % (n + 1);
                input[i] = null;
                input.Insert(indexToMove, word);


                input.Remove(null);

            }


            int maxLength = input.Max(x => x.Length);
            var result = new StringBuilder();

            for (int i = 0; i < maxLength; i++)
            {
                foreach (var word in input)
                {
                    if (word.Length>i)
                    {
                        result.Append(word[i]);
                    }
                }

            }
            

            Console.WriteLine(result.ToString());
        }

    }
}
