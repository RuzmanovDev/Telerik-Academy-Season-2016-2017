namespace BinaryToDecimal
{
    using System;

    public class BinaryToDecimal
    {
        public static void Main(string[] args)
        {
            string binary = Console.ReadLine();
            long decimalRepresentation = BinaryToDecimalConvert(binary);

            Console.WriteLine(decimalRepresentation);
        }

        private static long BinaryToDecimalConvert(string binary)
        {
            long result = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                result *= 2;

                result += binary[i] - '0';
            }

            return result;
        }
    }
}
