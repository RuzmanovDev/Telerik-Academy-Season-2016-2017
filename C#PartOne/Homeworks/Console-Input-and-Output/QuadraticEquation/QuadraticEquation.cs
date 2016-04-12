namespace QuadraticEquation
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class QuadraticEquation
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double descriminant = (b * b) - (4 * a * c);
            double x1, x2 = 0;

            if (descriminant == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
                Console.WriteLine("{0:F2}", x2);
                return;
            }
            else if (descriminant > 0)
            {
                x1 = (-b + Math.Sqrt(descriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(descriminant)) / (2 * a);
            }
            else
            {
                Console.WriteLine("no real roots");
                return;
            }

            Console.WriteLine("{0:F2}", x2);
            Console.WriteLine("{0:F2}", x1);
        }
    }
}
