namespace MoonGravity
{
    using System;

    class MoonGravity
    {
        private const double  MOON_GRAVITY = 0.17d;

        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            double result = weight * MOON_GRAVITY;
            Console.WriteLine("{0:F3}",result);

        }
    }
}
