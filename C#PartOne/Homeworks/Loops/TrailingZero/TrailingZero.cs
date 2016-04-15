namespace TrailingZero
{
    using System;

    public class TrailingZero
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int zeroCounter = 0;
            int divider = 5;
            while (n / divider >= 1)
            {
                zeroCounter += n / divider;
                divider *= 5;
            }

            Console.WriteLine(zeroCounter);
        }
    }
}
