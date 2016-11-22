using System;
using System.Collections.Generic;

namespace SortIntegersInIncreasingOrder
{
    class SortIntegersInIncreasingOrder
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter some numbers");
            while (true)
            {
                string line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                numbers.Add(int.Parse(line));
            }

            numbers.Sort();
            Console.Write("The sorted numbers are: ");
            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
