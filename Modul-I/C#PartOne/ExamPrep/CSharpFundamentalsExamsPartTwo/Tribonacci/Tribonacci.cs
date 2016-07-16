namespace Tribonacci
{
    using System;
    using System.Numerics;

    public class Tribonacci
    {
        public static void Main(string[] args)
        {
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(firstNumber);
            }
            else if (n == 2)
            {
                Console.WriteLine(secondNumber);
            }
            else if (n == 3)
            {
                Console.WriteLine(thirdNumber);
            }
            else
            {
                BigInteger nextElement = 0;
                for (int i = 0; i < n - 3; i++)
                {
                    nextElement = firstNumber + secondNumber + thirdNumber;
                    firstNumber = secondNumber;
                    secondNumber = thirdNumber;
                    thirdNumber = nextElement;
                }

                Console.WriteLine(nextElement);
            }
        }
    }
}
