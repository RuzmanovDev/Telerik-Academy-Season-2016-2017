namespace CalculateAgain
{
    using System;
    using System.Numerics;

    public class CalculateAgain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger factorielN = 1;
            BigInteger factorielK = 1;

            for (int i = 1; i <= n; i++)
            {
                if (i <= k)
                {
                    factorielN *= i;
                    factorielK *= i;
                }
                else
                {
                    factorielN *= i;
                }
            }

            Console.WriteLine(factorielN / factorielK);
        }
    }
}
