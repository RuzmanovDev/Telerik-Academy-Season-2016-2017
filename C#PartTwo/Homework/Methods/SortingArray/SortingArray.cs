namespace SortingArray
{
    using System;
    using System.Linq;

    class SortingArray
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Sort(numbers);


            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int FindMax(int[] numbers, int start, int end)
        {
            int max = int.MinValue;
            int maxIndex = 0;

            for (int i = start; i <= end; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        private static void Sort(int[] numbers)
        {
            int i = 0;
            int lastIndex = numbers.Length - 1;
            while (i != lastIndex)
            {
                int currentMaxIndex = FindMax(numbers, 0, lastIndex - i);
                if (numbers[lastIndex - i] < numbers[currentMaxIndex])
                {
                    int temp = numbers[lastIndex - i];
                    numbers[lastIndex - i] = numbers[currentMaxIndex];
                    numbers[currentMaxIndex] = temp;
                }
                i++;
            }
            // some kind of BubleSort???
        }
    }
}
