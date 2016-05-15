namespace TriangleSurfaceByTwoSidesAndAngle
{
    using System;
    using System.Globalization;
    using System.Threading;

    class TriangleSurfaceByTwoSidesAndAngle
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());

            double sin = Math.Sin(angle);
            Console.WriteLine("{0:F2}", (a * b * Math.Sin(angle * Math.PI / 180)) / 2);
        }
    }
}
