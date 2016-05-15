namespace TriangleSurface
{
    using System;
    using System.Globalization;
    using System.Threading;

    class TriangleSurface
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double side = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double area = (side * h) / 2.0;

            Console.WriteLine("{0:F2}", area);
        }
    }
}
