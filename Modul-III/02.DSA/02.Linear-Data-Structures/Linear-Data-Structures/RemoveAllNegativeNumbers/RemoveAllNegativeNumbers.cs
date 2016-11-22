using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveAllNegativeNumbers
{
    public class RemoveAllNegativeNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some numbers seperated by , :");
            var listOfNumbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> positiveNumbers = new List<int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                var num = listOfNumbers[i];

                if (num >= 0)
                {
                    positiveNumbers.Add(num);
                }
            }

            listOfNumbers = positiveNumbers;

            Console.WriteLine("Only positive numbers: ");
            Console.WriteLine(string.Join(", ",listOfNumbers));
           
        }
    }
}
