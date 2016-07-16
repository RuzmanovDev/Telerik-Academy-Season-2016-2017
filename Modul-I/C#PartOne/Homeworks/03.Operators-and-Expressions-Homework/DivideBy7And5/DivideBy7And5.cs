namespace DivideBy7And5
{
    using System;

    class DivideBy7And5
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number % 5 == 0 && number % 7 == 0)
            {
                Console.WriteLine("true {0}", number);
            }
            else
            {
                Console.WriteLine("false {0}", number);
            }

        }
    }
}
