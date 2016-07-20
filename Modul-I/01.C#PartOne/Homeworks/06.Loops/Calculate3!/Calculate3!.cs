namespace Calculate3_
{
    using System;
    using System.Numerics;

    public class Calculate3
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger factorielN = 1;
            BigInteger factorielK = 1;
            BigInteger factorielNK = 1;
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

            for (int i = 1; i <= n - k; i++)
            {
                factorielNK *= i;
            }

            BigInteger result = factorielN / (factorielK * factorielNK);
            Console.WriteLine(result);
        }
    }
}
