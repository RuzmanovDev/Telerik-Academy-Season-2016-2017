namespace PointCircleRectangle
{
    using System;
    using System.Globalization;
    using System.Threading;

    class PointCircleRectangle
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            decimal x = decimal.Parse(Console.ReadLine());
            decimal y = decimal.Parse(Console.ReadLine());

            bool insideCircle = (x - 1m) * (x - 1m) + (y - 1m) * (y - 1m) <= 1.5m * 1.5m ? true : false;
            bool insideRectangle = (x >= -1m && x <= 5m) && (y >= -1m && y <= 1m) ? true : false;

            if (insideCircle && insideRectangle)
            {
                Console.WriteLine("inside circle inside rectangle");
            }
            else if (!insideCircle && insideRectangle)
            {
                Console.WriteLine("outside circle inside rectangle");
            }
            else if (insideCircle && !insideRectangle)
            {
                Console.WriteLine("inside circle outside rectangle");
            }
            else
            {
                Console.WriteLine("outside circle outside rectangle");
            }
        }
    }
}
