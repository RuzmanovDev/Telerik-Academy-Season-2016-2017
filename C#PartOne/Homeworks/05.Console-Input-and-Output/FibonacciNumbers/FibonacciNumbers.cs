namespace FibonacciNumbers
{
    using System;
    using System.Collections.Generic;

    public class FibonacciNumbers
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            List<long> fibonacci = new List<long>();
            long firstElement = 0;
            long secondElement = 1;

            fibonacci.Add(firstElement);
            fibonacci.Add(secondElement);

            for (int i = 0; i < n - 1; i++)
            {
                long nextElement = firstElement + secondElement;
                fibonacci.Add(nextElement);
                firstElement = secondElement;
                secondElement = nextElement;
            }

            for (int i = 0; i < n; i++)
            {
                if (i < n - 1)
                {
                    Console.Write(fibonacci[i] + ", ");
                }
                else
                {
                    Console.WriteLine(fibonacci[i]);
                }
            }
        }
    }
}
