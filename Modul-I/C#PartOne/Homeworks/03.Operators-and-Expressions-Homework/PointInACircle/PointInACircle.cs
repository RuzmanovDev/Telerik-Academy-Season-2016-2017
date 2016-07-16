namespace PointInACircle
{
    using System;
    using System.Globalization;
    using System.Threading;

    class PointInACircle
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            
            double distance = Math.Sqrt((0 - x) * (0 - x) + (0 - y) * (0 - y)); //dist = math.sqrt((center_x - x) ** 2 + (center_y - y) ** 2)
            bool isInTheCirlce = distance <= 2 ? true : false; //x * x + y + y <= 4 ? true : false;
            if (isInTheCirlce)
            {
                Console.WriteLine("yes {0:F2}", distance);
            }
            else
            {
                Console.WriteLine("no {0:F2}", distance);
            }

        }
    }
}
