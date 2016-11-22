using System;

namespace CombinationsWithDuplicates
{
    class CombinationsWithDuplicates
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            CombsWithRep(0, new int[k], 1, n);
        }

        private static void CombsWithRep(int currentIndex, int[] numbers, int value, int n)
        {
            if (currentIndex == numbers.Length)
            {
                Console.WriteLine(string.Join(", ", numbers));
                return;
            }

            for (int i = value; i <= n; i++)
            {
                numbers[currentIndex] = i;
                CombsWithRep(currentIndex + 1, numbers, i, n);
            }
        }
    }
}