namespace SquareRoot
{
    using System;
    using System.Globalization;
    using System.Threading;

    class SquareRoot
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            try
            {
                double n = double.Parse(Console.ReadLine());
                double sqrt = Math.Sqrt(n);
                if (n < 0)
                {
                    throw new Exception();
                }

                Console.WriteLine("{0:F3}", sqrt);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }

        }
    }
}