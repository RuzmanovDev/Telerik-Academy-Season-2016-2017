namespace HexadecimalToDecimal
{
    using System;

    public class HexadecimalToDecimal
    {
        public static void Main(string[] args)
        {
            string hex = Console.ReadLine();
            long decimalFromHex = HexadecimalToDecimalConvert(hex);

            Console.WriteLine(decimalFromHex);
        }

        private static long HexadecimalToDecimalConvert(string hex)
        {
            long decimalNumber = 0;
            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            for (int i = 0; i < hex.Length; i++)
            {
                decimalNumber *= 16;
                int weight = Array.IndexOf(digits, hex[i]);
                decimalNumber += weight;
            }

            return decimalNumber;
        }
    }
}
