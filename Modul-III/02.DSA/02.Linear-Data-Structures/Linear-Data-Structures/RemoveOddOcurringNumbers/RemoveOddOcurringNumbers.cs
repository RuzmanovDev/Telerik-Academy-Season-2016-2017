using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOcurringNumbers
{
    public class RemoveOddOcurringNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some numbers seperated by , :");
            var listOfNumbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                var currentNumber = listOfNumbers[i];
                if (!dictionary.Keys.Contains(currentNumber))
                {
                    dictionary.Add(currentNumber, 1);
                }
                else
                {
                    dictionary[currentNumber] += 1;
                }
            }

            var numbersOccurringEvenNumberOfTimes = new List<int>();

            foreach (var item in dictionary)
            {
                if (item.Value % 2 == 0)
                {
                    numbersOccurringEvenNumberOfTimes.AddRange(Enumerable.Repeat(item.Key, item.Value));
                }
            }

            Console.WriteLine(string.Join(", ",numbersOccurringEvenNumberOfTimes));
        }
    }
}
