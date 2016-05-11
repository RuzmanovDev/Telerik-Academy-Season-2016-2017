namespace FirstLargerThanNeighbour
{
    using System;
    using System.Linq;

    class FirstLargerThanNeighbour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int firstLargerThanNeighbourIndex = FirstLargerThanNeighbourIndex(numbers);

            Console.WriteLine(firstLargerThanNeighbourIndex);

        }
        static int FirstLargerThanNeighbourIndex(int[] numbers)
        {
            int firstLargerThanNeighbourIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (i != 0
                    && i < numbers.Length - 1
                    && numbers[i - 1] < currentNumber
                    && currentNumber > numbers[i + 1]
                    )
                {
                    firstLargerThanNeighbourIndex = i;
                    break;
                }

            }
            return firstLargerThanNeighbourIndex;
        }
    }
}

