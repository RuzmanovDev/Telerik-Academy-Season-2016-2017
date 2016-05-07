using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerg
{
    class Zerg
    {
        static void Main(string[] args)
        {
            string[] alphabet = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };

            string input = Console.ReadLine();
            long result = 0;
            for (int i = 0; i < input.Length; i += 4)
            {
                string currentWord = input.Substring(i, 4);

                result *= 15;
                int index = Array.IndexOf(alphabet, currentWord);
                result += index;

            }
            Console.WriteLine(result);

        }
    }
}
