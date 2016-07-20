namespace Task1
{
    using System;
    using System.Numerics;

    class Task1
    {
        static void Main(string[] args)
        {
            string[] digits = { "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan" };

            string firstNumber = Console.ReadLine();
            char sign = char.Parse(Console.ReadLine());
            string secondNumber = Console.ReadLine();

            BigInteger firstAsDecimal = ConvertToDecimal(firstNumber, digits);
            BigInteger secondAsDecimal = ConvertToDecimal(secondNumber, digits);
            //  Console.WriteLine(firstAsDecimal);
            // Console.WriteLine(secondAsDecimal);
            BigInteger result = 0;
            string resultAsStr = string.Empty;
            if (sign == '+')
            {
                result = firstAsDecimal + secondAsDecimal;
                resultAsStr = ConvertToMSG(result, digits);
            }
            else
            {
                result = firstAsDecimal - secondAsDecimal;
                resultAsStr = ConvertToMSG(result, digits);

            }
            Console.WriteLine(resultAsStr);
        }

        private static string ConvertToMSG(BigInteger number, string[] digits)
        {
            string result = string.Empty;
            while (number != 0)
            {
                int residual = (int)(number % 10);
                string digit = digits[residual];
                result = digit + result;
                number /= 10;
            }

            return result;
        }

        private static BigInteger ConvertToDecimal(string firstNumber, string[] digits)
        {
           BigInteger result = 0;
            for (int i = 0; i < firstNumber.Length - 1; i += 3)
            {
                string currentDigit = firstNumber.Substring(i, 3);
                result *= 10;
                result += (BigInteger)Array.IndexOf(digits, currentDigit);
            }

            return result;
        }
    }
}
