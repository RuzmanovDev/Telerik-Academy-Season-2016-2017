using System;
using System.Collections.Generic;
using System.Linq;

namespace CountOfElements
{
    public class CountOfElements
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some numbers seperated by , :");
            var listOfNumbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Dictionary<int, int> numbersOccurances = new Dictionary<int, int>();
            foreach (var number in listOfNumbers)
            {
                if (number >= 0 && number <= 1000)
                {
                    if (!numbersOccurances.ContainsKey(number))
                    {
                        numbersOccurances.Add(number, 1);
                    }
                    else
                    {
                        numbersOccurances[number] += 1;
                    }
                }
            }

            foreach (KeyValuePair<int, int> kvp in numbersOccurances)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}
