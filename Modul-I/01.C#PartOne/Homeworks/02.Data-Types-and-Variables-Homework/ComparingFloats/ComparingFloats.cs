namespace ComparingFloats
{
    using System;
    using System.Globalization;
    using System.Threading;

    class ComparingFloats
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

           // float difference = (float)Math.Round(Math.Abs(a - b), 6);

            if (Math.Abs(a - b) < 0.000001)
            {
                Console.WriteLine("true");

            }
            else 
            {
                Console.WriteLine("false");
            }
        }
    }
}
