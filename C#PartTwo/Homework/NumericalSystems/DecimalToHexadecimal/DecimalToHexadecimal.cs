namespace DecimalToHexadecimal
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DecimalToHexadecimal
    {
        public static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            string hex = DecimalToHexadecimalConvert(number);

            Console.WriteLine(hex);

        }

        private static string DecimalToHexadecimalConvert(long number)
        {
            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            var residuals = new Stack<char>();

            while (number != 0)
            {
                long residual = number % 16;
                char hexChar = digits[residual];

                residuals.Push(hexChar);

                number /= 16;
            }

            var hex = new StringBuilder();

            while (residuals.Count != 0) 
            {
                hex.Append(residuals.Pop());

            }
            return hex.ToString();
        }
    }
}
