using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPartTwoEveningMarch2015
{
    class EvenDifference
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] numbersAsString = input.Split(' ');
            long[] numbers = new long[numbersAsString.Length];
            List<long> temp = new List<long>();
            long evenSum = 0;

            //parses the string array into int
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = long.Parse(numbersAsString[i]);

            }

            //logic
            for (int i = 1; i < numbers.Length;)
            {
                if (isEven(Math.Abs((int)numbers[i] - (int)numbers[i - 1])))
                {
                    temp.Add(Math.Abs(numbers[i] - numbers[i - 1]));

                    i += 2;
                }
                else
                {
                    temp.Add(Math.Abs(numbers[i] - numbers[i - 1]));
                    i++;
                }
            }
            //sum the even numbers
            foreach (var num in temp)
            {
                if (isEven((int)num))
                {
                    evenSum += num;
                }
            }
            //Print the results
            Console.WriteLine(evenSum);
        }



        static bool isEven(long number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
