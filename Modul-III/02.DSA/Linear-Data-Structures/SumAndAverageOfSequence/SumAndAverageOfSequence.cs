using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAndAverageOfSequence
{
    public class SumAndAverageOfSequence
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == string.Empty)
                {
                    break;
                }

                numbers.Add(int.Parse(input));
            }

            var sum = numbers.Sum();
            var average = numbers.Average();

            Console.WriteLine(sum);
            Console.WriteLine(average);
        }
    }
}
