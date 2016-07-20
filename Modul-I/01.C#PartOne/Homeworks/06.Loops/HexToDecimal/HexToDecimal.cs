namespace HexToDecimal
{
    using System;

    public class HexToDecimal
    {
        public static void Main(string[] args)
        {
            string hex = Console.ReadLine();
            long result = 0;
            int power = hex.Length - 1;

            for (int i = 0; i < hex.Length; i++)
            {
                long currentNumber = 0;

                switch (hex[i])
                {
                    case 'A':
                        currentNumber = 10;
                        break;
                    case 'B':
                        currentNumber = 11;
                        break;
                    case 'C':
                        currentNumber = 12;
                        break;
                    case 'D':
                        currentNumber = 13;
                        break;
                    case 'E':
                        currentNumber = 14;
                        break;
                    case 'F':
                        currentNumber = 15;
                        break;
                    default:
                        currentNumber = hex[i] - '0';
                        break;
                }

                result += currentNumber * (long)Math.Pow(16, power);
                power--;
            }

            Console.WriteLine(result);
        }
    }
}
