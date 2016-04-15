namespace NumberComparer
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class NumberComparer
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Max(a, b));
        }
    }
}
