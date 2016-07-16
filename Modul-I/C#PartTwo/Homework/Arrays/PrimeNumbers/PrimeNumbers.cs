namespace PrimeNumbers
{
    using System;

    class PrimeNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int j = n; j >= 0; j--)
            {
                int number = j;
                bool isPrime = true;

                for (int i = 2; i <= (int)Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine(number);
                    break;
                }
            }


        }
    }
}
