namespace BinaryToHexadecimal
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryToHexadecimal
    {
        public static void Main(string[] args)
        {
            string binary = Console.ReadLine();
            string hex = BinaryToHex(binary);

            Console.WriteLine(hex);

        }

        private static string BinaryToHex(string binary)
        {
            var hex = new StringBuilder();
            Dictionary<string, string> digits = new Dictionary<string, string>()
            {
                {"0000", "0"},
                {"0001", "1"},
                {"0010", "2"},
                {"0011", "3"},
                {"0100", "4"},
                {"0101", "5"},
                {"0110", "6"},
                {"0111", "7"},
                {"1000", "8"},
                {"1001", "9"},
                {"1010", "A"},
                {"1011", "B"},
                {"1100", "C"},
                {"1101", "D"},
                {"1110", "E"},
                {"1111", "F"},
            };

            // Add leading zeroes if needed
            while (binary.Length % 4 != 0)
            {
                binary = "0" + binary;
            }

            for (int i = 0; i < binary.Length - 3; i += 4)
            {
                string binaryNumber = binary.Substring(i, 4);
                string hexNumber = digits[binaryNumber];
                hex.Append(hexNumber);
            }
            return hex.ToString();
        }
    }
}