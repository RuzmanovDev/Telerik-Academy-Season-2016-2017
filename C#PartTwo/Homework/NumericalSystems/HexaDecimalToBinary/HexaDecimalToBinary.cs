namespace HexaDecimalToBinary
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HexaDecimalToBinary
    {
        public static void Main(string[] args)
        {
            string hex = Console.ReadLine();

            string binary = HexToBinary(hex);

            Console.WriteLine(binary);
        }

        private static string HexToBinary(string hex)
        {
            var binary = new StringBuilder();

            Dictionary<string, string> digits = new Dictionary<string, string>()
            {
                {"0", "0000" },
                {"1", "0001" },
                {"2", "0010" },
                {"3", "0011" },
                {"4", "0100" },
                {"5", "0101" },
                {"6", "0110" },
                {"7", "0111" },
                {"8", "1000" },
                {"9", "1001" },
                {"A", "1010" },
                {"B", "1011" },
                {"C", "1100" },
                {"D", "1101" },
                {"E", "1110" },
                {"F", "1111" },

            };
            for (int i = 0; i < hex.Length; i++)
            {
                string digit = hex[i].ToString();
                binary.Append(digits[digit]);
            }

            string result = binary.ToString();
            result = result.TrimStart('0');
            return result;
        }
    }
}