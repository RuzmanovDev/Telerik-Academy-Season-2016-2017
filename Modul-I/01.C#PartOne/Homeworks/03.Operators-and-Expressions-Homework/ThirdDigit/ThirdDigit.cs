namespace ThirdDigit
{
    using System;

    class ThirdDigit
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int thirdDigit = 0;

            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                {
                    thirdDigit = number % 10;
                }
                else
                {
                    number /= 10;
                }

            }

            if (thirdDigit == 7)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false {0}", thirdDigit);
            }

        }
    }
}
