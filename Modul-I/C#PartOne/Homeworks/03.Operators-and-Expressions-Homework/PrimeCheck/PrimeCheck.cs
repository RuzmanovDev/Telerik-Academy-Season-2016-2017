namespace PrimeCheck
{
    using System;

    class PrimeCheck
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int template = (int)Math.Sqrt(number);
            bool isPrime = true;

            if (number < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= template; i++)
                {
                    if (number % i == 0 && i != number)
                    {
                        isPrime = false;
                       
                    }

                }
            }


            if (isPrime)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
