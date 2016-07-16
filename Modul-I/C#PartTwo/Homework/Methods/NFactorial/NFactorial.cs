namespace NFactorial
{
    using System;
    using System.Numerics;

    public class NFactorial
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger nFactorial = Factorial(n);
            Console.WriteLine(nFactorial);
        }

        private static BigInteger Factorial(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
