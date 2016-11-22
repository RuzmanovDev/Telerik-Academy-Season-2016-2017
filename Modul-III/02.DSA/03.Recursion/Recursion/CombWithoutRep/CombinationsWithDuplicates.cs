using System;

namespace CombWithoutRep
{
    public class CombinationsWithDuplicates
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            CombWithoutRep(0, new int[k], 1, n);
        }

        private static void CombWithoutRep(int currentIndex, int[] numbers, int value, int n)
        {
            if (currentIndex == numbers.Length)
            {
                Console.WriteLine(string.Join(", ", numbers));
                return;
            }

            for (int i = value; i <= n; i++)
            {
                numbers[currentIndex] = i;
                CombWithoutRep(currentIndex + 1, numbers, i + 1, n);
            }
        }
    }
}
