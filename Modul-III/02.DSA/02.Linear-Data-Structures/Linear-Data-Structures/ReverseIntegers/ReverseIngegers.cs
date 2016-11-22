using System;
using System.Collections.Generic;

namespace ReverseIntegers
{
    public class ReverseIngegers
    {
        static void Main(string[] args)
        {
            Console.Write("How many numbers would you like to read? ");
            int numbersToRead = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            Console.WriteLine("Enter the numbers: ");
            for (int i = 0; i < numbersToRead; i++)
            {
                Console.Write($"number {i} = ");
                int number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }

            Console.WriteLine("The numbers in reversed order are: ");
            while (numbers.Count != 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
