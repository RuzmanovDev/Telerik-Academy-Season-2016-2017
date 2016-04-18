namespace DiamondTrolls
{
    using System;

    public class DiamondTrolls
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = (n * 2) + 1;
            int height = (6 + ((n - 3) / 2) * 3);

            int topDots = (width - n) / 2;
            char dot = '.';
            char asterix = '*';

            Console.Write(new string(dot, topDots));
            Console.Write(new string(asterix, n));
            Console.WriteLine(new string(dot, topDots));
            topDots--;
            int middleDots = topDots;
            for (int i = 0; i < (n + 1) / 2 - 1; i++)
            {
                Console.Write(new string(dot, topDots));
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.WriteLine(new string(dot, topDots));
                topDots--;
                middleDots++;
            }

            Console.WriteLine(new string(asterix, width));
            topDots = 1;
            middleDots--;

            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(new string(dot, topDots));
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.WriteLine(new string(dot, topDots));
                topDots++;
                middleDots--;
                if (middleDots < 0)
                {
                    middleDots = 0;
                }
            }

            Console.Write(new string(dot, topDots));
            Console.Write(asterix);
            Console.WriteLine(new string(dot, topDots));
        }
    }

}

