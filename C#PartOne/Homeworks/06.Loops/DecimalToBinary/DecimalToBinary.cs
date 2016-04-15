namespace DecimalToBinary
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinary
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> result = new Stack<int>();

            while (number > 0)
            {
                int digit = number % 2;
                result.Push(digit);
                number /= 2;
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }

            Console.WriteLine();
        }
    }
}
