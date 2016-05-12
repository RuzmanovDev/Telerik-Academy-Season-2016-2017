namespace BinaryShort
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryShort
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string binary = ShortToBinaryConvertion(number);
            // Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
        
            Console.WriteLine(binary);

        }

        private static string ShortToBinaryConvertion(int number)
        {
            string binaryNumber = string.Empty;

            for (int i = 15; i >= 0; i--)
            {
                binaryNumber = ((number % 2) & 1) + binaryNumber;
                number >>= 1;
                //if (i % 4 == 0) binary = " " + binary;    // for better print
            }
            return binaryNumber;
        }
    }
}