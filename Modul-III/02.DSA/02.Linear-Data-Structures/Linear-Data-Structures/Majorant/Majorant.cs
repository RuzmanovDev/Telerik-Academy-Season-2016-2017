using System;
using System.Collections.Generic;
using System.Linq;

namespace Majorant
{
    public class Majorant
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

                if (!numbersOccurances.ContainsKey(number))
                {
                    numbersOccurances.Add(number, 1);
                }
                else
                {
                    numbersOccurances[number] += 1;
                }

            }

            var majorant = numbersOccurances.FirstOrDefault(n => n.Value == listOfNumbers.Count / 2 + 1);
            Console.WriteLine(majorant.Key);
        }
    }
}
