using System;

namespace VariationsWithouthRep
{
    class VariationsWithouthRep
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many words will you enter? ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("How many you wish to take?");
            int k = int.Parse(Console.ReadLine());
            string[] set = new string[n];
            bool[] used = new bool[n];

            Console.WriteLine("Enter words: ");
            for (int i = 0; i < set.Length; i++)
            {
                Console.Write($"word[{i}]= ");
                set[i] = Console.ReadLine();
            }


            GenerateVariations(0, new string[k], set, used);
        }

        private static void GenerateVariations(int currentIndex, string[] variations, string[] set, bool[] used)
        {
            if (currentIndex >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i <= variations.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[currentIndex] = set[i];
                    GenerateVariations(currentIndex + 1, variations, set, used);
                    used[i] = false;

                }
            }
        }
    }
}
