namespace DecimalToBinary
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DecimalToBinary
    {
        public static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            string binary = DecimalToBinaryConvert(number);

            Console.WriteLine(binary);
        }

        private static string DecimalToBinaryConvert(long number)
        {
            var residues = new Stack<long>();

            while (number != 0)
            {
                long num = number % 2;
                residues.Push(num);

                number /= 2;
            }

            var binary = new StringBuilder();
            while (residues.Count != 0)
            {
                binary.Append(residues.Pop());
            }

            return binary.ToString();
        }
    }
}
