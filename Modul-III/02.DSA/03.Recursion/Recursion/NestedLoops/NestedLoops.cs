using System;

namespace NestedLoops
{
    public class NestedLoops
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            NesedLoops(n, 0, new int[n]);
        }

        private static void NesedLoops(int n, int currentLoop, int[] numbers)
        {
            if (currentLoop == n)
            {
                Console.WriteLine(string.Join(", ", numbers));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                numbers[currentLoop] = i;
                NesedLoops(n, currentLoop + 1, numbers);
            }
        }
    }
}
