namespace CatalanNumbers
{
    using System;
    using System.Numerics;

    public class CatalanNumbers
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factroielN = 1;
            BigInteger factroiel2N = 1;
            BigInteger factroielNplus1 = 1;

            for (int i = 1; i <= n; i++)
            {
                factroielN *= i;
            }

            for (int i = 1; i <= 2 * n; i++)
            {
                factroiel2N *= i;
            }

            for (int i = 1; i <= n + 1; i++)
            {
                factroielNplus1 *= i;
            }

            BigInteger result = factroiel2N / (factroielNplus1 * factroielN);
            Console.WriteLine(result);
        }
    }
}
