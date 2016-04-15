namespace BiggestOfThree
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class BiggestOfThree
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double biggest = Math.Max(a, Math.Max(b, c));
            Console.WriteLine(biggest);
        }
    }
}
