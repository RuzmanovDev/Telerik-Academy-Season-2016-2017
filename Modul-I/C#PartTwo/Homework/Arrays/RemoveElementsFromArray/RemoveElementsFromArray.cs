namespace RemoveElementsFromArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveElementsFromArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int[] longSequence = LongestIncSubsequence(numbers);
            Console.WriteLine(numbers.Length- longSequence.Length);
        }
        static int[] LongestIncSubsequence(int[] array)
        {
            int[] increasingLengths = new int[array.Length];
            increasingLengths[0] = 1;
            for (int i = 1; i < increasingLengths.Length; i++)
            {
                int maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] <= array[i] && increasingLengths[j] > maxLength)
                    {
                        maxLength = increasingLengths[j];
                    }
                }
                increasingLengths[i] = maxLength + 1;
            }

            int[] sortedSubset = new int[increasingLengths.Max()];
            int serialNumber = increasingLengths.Max();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (serialNumber == increasingLengths[i])
                {
                    sortedSubset[serialNumber - 1] = array[i];
                    serialNumber--;
                }
            }

            return sortedSubset;
        }

    }
}
