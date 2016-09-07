namespace SaddyCopper
{
    using System;
    using System.Numerics;

    public class SaddyCopper
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int transCount = 0;

            while (input.Length > 1 && transCount < 10)
            {
                BigInteger product = 1;

                while (input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    int sum = 0;

                    for (int i = 0; i < input.Length; i += 2)
                    {
                        sum += input[i] - '0';
                    }

                    product *= sum != 0 ? sum : 1;
                }

                transCount++;
                input = product.ToString();
            }
            if (transCount < 10)
            {
                Console.WriteLine(transCount);
            }
            Console.WriteLine(input);
        }
    }
}
