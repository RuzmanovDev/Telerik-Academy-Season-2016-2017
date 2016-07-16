namespace OneSystemToAnyOther
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OneSystemToAnyOther
    {
        static char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public static void Main(string[] args)
        {
            int systemBase = int.Parse(Console.ReadLine());
            string number = Console.ReadLine();

            int toBase = int.Parse(Console.ReadLine());

            string result = UniversalConverter(number, systemBase, toBase);
            Console.WriteLine(result);

        }

        private static string UniversalConverter(string number, int systemBase, int toBase)
        {
            long decimalNumber = 0;
            // first convert it to decimal
            if (systemBase == 10)
            {
                decimalNumber = long.Parse(number);
            }
            else
            {
                decimalNumber = ConvertToDecimal(number, systemBase);
            }

            // Then convert it to the specified system
            var residuals = new Stack<char>();

            while (decimalNumber != 0)
            {
                long residual = decimalNumber % toBase;
                char hexChar = digits[residual];

                residuals.Push(hexChar);

                decimalNumber /= toBase;
            }

            var result = new StringBuilder();

            while (residuals.Count != 0)
            {
                result.Append(residuals.Pop());
            }

            return result.ToString();
        }

        private static long ConvertToDecimal(string number, int systemBase)
        {
            long decimalNumber = 0;

            for (int i = 0; i < number.Length; i++)
            {
                decimalNumber *= systemBase;
                int weight = Array.IndexOf(digits, number[i]);
                decimalNumber += weight;
            }
            return decimalNumber;
        }
    }
}