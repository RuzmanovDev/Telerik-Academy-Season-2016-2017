namespace Trapezoids
{
    using System;
    using System.Globalization;
    using System.Threading;

    class Trapezoids
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = ((a + b) * h) / 2;

            Console.WriteLine("{0:F7}", area);
        }
    }
}
