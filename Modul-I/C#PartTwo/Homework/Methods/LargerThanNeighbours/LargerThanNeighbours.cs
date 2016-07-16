namespace LargerThanNeighbours
{
    using System;
    using System.Linq;

    public class LargerThanNeighbours
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int largerThanNeighbourCount = LargerThanNeighboursCount(numbers);

            Console.WriteLine(largerThanNeighbourCount);
        }

        private static int LargerThanNeighboursCount(int[] numbers)
        {
            int largerThanNeighbpurCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (i != 0
                    && i < numbers.Length - 1
                    && numbers[i - 1] < currentNumber
                    && currentNumber > numbers[i + 1])
                {
                    largerThanNeighbpurCount++;
                }
            }

            return largerThanNeighbpurCount;
        }
    }
}
