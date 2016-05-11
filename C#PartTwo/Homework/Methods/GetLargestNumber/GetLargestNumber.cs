namespace GetLargestNumber
{
    using System;
    using System.Linq;

    class GetLargestNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int max = GetMaxValue(numbers);
            Console.WriteLine(max);
        }

        private static int GetMaxValue(int[] numbers)
        {
            int max = int.MinValue;
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            return max;
        }
    }
}
