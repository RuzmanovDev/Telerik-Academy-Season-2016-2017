using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetProblem
{
    class SubsetProblem
    {
        static void Main(string[] args)
        {
            long sum = long.Parse(Console.ReadLine());
            long length = long.Parse(Console.ReadLine());

            long[] numbers = new long[length];
            int subsetCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }

            foreach (var number in numbers)
            {
                if (number == sum)
                {
                    subsetCount++;
                }
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                long currentNumber = numbers[i];
                for (int j = 1; j < numbers.Length; j++)
                {
                    if (currentNumber + numbers[j] == sum)
                    {
                        subsetCount++;
                    }
                }
            }

            Console.WriteLine(subsetCount);
        }
    }
}
