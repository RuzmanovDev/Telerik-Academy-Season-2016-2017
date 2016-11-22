using System;
using System.Linq;

namespace LongestSubsequenceOfEqualNumbers
{
    public class LongestSubsequenceOfEqualNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some numbers seperated by , :");
            var listOfNumbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = GetLogestSubsequenceOfEqualNumbers(listOfNumbers);
            Console.WriteLine(result);
        }

        public static string GetLogestSubsequenceOfEqualNumbers(int[] listOfNumbers)
        {
            int maxSequenceCount = int.MinValue;
            int currentSequence = 0;
            int numberInSequence = 0;

            for (int i = 0; i < listOfNumbers.Length - 1; i++)
            {
                int currentNumber = listOfNumbers[i];
                int nextNumber = listOfNumbers[i + 1];
                if (currentNumber == nextNumber)
                {
                    currentSequence++;
                }
                else
                {
                    currentSequence = 0;
                }

                if (currentSequence > maxSequenceCount)
                {
                    maxSequenceCount = currentSequence;
                    numberInSequence = currentNumber;
                }
            }

            var longestSequence = Enumerable.Repeat(numberInSequence, maxSequenceCount);
            return string.Join(", ", longestSequence);
        }
    }
}
