namespace Circle
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Circle
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double r = double.Parse(Console.ReadLine());

            double perimeter = 2 * Math.PI * r;
            double area = Math.PI * (r * r);

            Console.WriteLine("{0:F2} {1:F2}", perimeter, area);
        }
    }
}
