using System;

namespace AngryFemaleGps
{
    class AngryFemaleGps
    {
        static void Main(string[] args)
        {

            long n = long.Parse(Console.ReadLine());
            if (n < 0)
            {
                n *= -1;
            }
            long summOfEvenDigits = 0;
            long summOfOddDigits = 0;

            while (n > 0)
            {
                long currentNumber = n % 10;
                if (currentNumber % 2 == 0)
                {
                    summOfEvenDigits += currentNumber;
                }
                else
                {
                    summOfOddDigits += currentNumber;
                }

                n /= 10;
            }
            if (summOfEvenDigits > summOfOddDigits)
            {
                Console.WriteLine("right {0}", summOfEvenDigits);
            }
            else if (summOfEvenDigits < summOfOddDigits)
            {
                Console.WriteLine("left {0}", summOfOddDigits);

            }
            else
            {
                Console.WriteLine("straight {0}", summOfOddDigits);
            }

        }
    }
}
