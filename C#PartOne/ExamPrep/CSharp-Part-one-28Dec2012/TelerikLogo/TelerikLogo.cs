namespace TelerikLogo
{
    using System;

    public class TelerikLogo
    {
        public static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = x;
            int z = (x / 2) + 1;
            int width = (x * 3) - 2;
            int topDots = z - 1;
            int topMiddleDots = width - ((topDots * 2) + 2);
            int dotsBetweenHorns = -1;
            for (int i = 0; i < z; i++)
            {
                Console.Write(new string('.', topDots));
                Console.Write("*");
                if (i > 0)
                {
                    Console.Write(new string('.', dotsBetweenHorns));
                    Console.Write("*");
                }

                Console.Write(new string('.', topMiddleDots));
                Console.Write("*");

                if (i > 0)
                {
                    Console.Write(new string('.', dotsBetweenHorns));
                    Console.Write("*");
                }

                Console.WriteLine(new string('.', topDots));
                topDots--;
                topMiddleDots -= 2;
                dotsBetweenHorns += 2;
            }

            topDots++;

            for (int i = 0; i < y - z - 1; i++)
            {
                Console.Write(new string('.', dotsBetweenHorns));
                Console.Write("*");
                Console.Write(new string('.', topMiddleDots));
                Console.Write("*");
                Console.WriteLine(new string('.', dotsBetweenHorns));
                dotsBetweenHorns++;
                topMiddleDots -= 2;
            }

            Console.Write(new string('.', dotsBetweenHorns));
            Console.Write("*");
            Console.WriteLine(new string('.', dotsBetweenHorns));
            dotsBetweenHorns--;
            topMiddleDots = 1;

            for (int i = 0; i < x - 1; i++)
            {
                Console.Write(new string('.', dotsBetweenHorns));
                Console.Write("*");
                Console.Write(new string('.', topMiddleDots));
                Console.Write("*");
                Console.WriteLine(new string('.', dotsBetweenHorns));
                topMiddleDots += 2;
                dotsBetweenHorns--;
            }

            dotsBetweenHorns += 2;
            topMiddleDots -= 4;
            if (topMiddleDots < 0)
            {
                topMiddleDots = 1;
            }

            for (int i = 0; i < x - 2; i++)
            {
                Console.Write(new string('.', dotsBetweenHorns));
                Console.Write("*");
                Console.Write(new string('.', topMiddleDots));
                Console.Write("*");
                Console.WriteLine(new string('.', dotsBetweenHorns));
                topMiddleDots -= 2;
                dotsBetweenHorns++;
            }

            Console.Write(new string('.', dotsBetweenHorns));
            Console.Write("*");
            Console.WriteLine(new string('.', dotsBetweenHorns));
        }
    }
}
