using System;


namespace EggCelent
{
    class EggCelent
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int topDots = n + 1;
            int topAsterix = n - 1;


            Console.Write(new string('.', topDots));
            Console.Write(new string('*', topAsterix));
            Console.WriteLine(new string('.', topDots));

            topDots -= 2;
            int middleDos = n + 1;
            int bottomSingleDots = -1;
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(new string('.', topDots));
                Console.Write("*");
                Console.Write(new string('.', middleDos));
                Console.Write("*");
                Console.WriteLine(new string('.', topDots));
                topDots -= 2;
                if (topDots >= 0)
                {
                    middleDos += 4;
                }

                if (topDots <= 0)
                {
                    topDots = 1;
                    bottomSingleDots++;
                }
            }

            //cracked part


            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 3 * n + 1; c++)
                {
                    if ((r == 0 && c == 0) || (r == 0 && c == 3 * n) || (r == 1 && c == 0) || (r == 1 && c == 3 * n))
                    {
                        Console.Write(".");
                    }
                    else if ((r == 0 && c == 1) || (r == 0 && c == 3 * n - 1) || (r == 1 && c == 1) || (r == 1 && c == 3 * n - 1))
                    {
                        Console.Write("*");
                    }
                    else if (r == 0 && c % 2 == 0 && c > 0)
                    {
                        Console.Write("@");
                    }
                    else if (r == 1 && c % 2 != 0 && c > 0)
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            //bottom
            for (int i = 0; i < n - 2; i++)
            {
                if (bottomSingleDots > 0)
                {
                    Console.Write(new string('.', topDots));
                    Console.Write("*");
                    Console.Write(new string('.', middleDos));
                    Console.Write("*");
                    Console.WriteLine(new string('.', topDots));
                    bottomSingleDots--;

                }
                else
                {
                    Console.Write(new string('.', topDots));
                    Console.Write("*");
                    Console.Write(new string('.', middleDos));
                    Console.Write("*");
                    Console.WriteLine(new string('.', topDots));
                    topDots += 2;
                    middleDos -= 4;
                }

            }
            topDots = n + 1;
            topAsterix = n - 1;
            Console.Write(new string('.', topDots));
            Console.Write(new string('*', topAsterix));
            Console.WriteLine(new string('.', topDots));

        }
    }
}
