using System;

namespace Variations
{
    public class Variations
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many words will you enter? ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("How many you wish to take?");
            int k = int.Parse(Console.ReadLine());
            string[] set = new string[n];
            Console.WriteLine("Enter words: ");
            for (int i = 0; i < set.Length; i++)
            {
                Console.Write($"word[{i}]= ");
                set[i] = Console.ReadLine();
            }
           

            GenerateVariations(0, new string[k], set);
        }

        private static void GenerateVariations(int currentIndex, string[] variations, string[] set)
        {
            if (currentIndex >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i <= variations.Length; i++)
            {
                variations[currentIndex] = set[i];
                GenerateVariations(currentIndex + 1, variations, set);
            }
        }
    }
}
