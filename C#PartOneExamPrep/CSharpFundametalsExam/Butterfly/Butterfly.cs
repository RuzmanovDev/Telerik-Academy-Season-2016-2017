using System;

namespace Butterfly
{
    class Butterfly
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int top = n - 2;

            for (int i = 0; i < top; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(new string('*', n - 2));
                    Console.Write("\\ /");
                    Console.WriteLine(new string('*', n - 2));
                }
                else
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write("\\ /");
                    Console.WriteLine(new string('-', n - 2));
                }
            }

            Console.Write(new string(' ', n - 1));
            Console.Write("@");
            Console.WriteLine(new string(' ', n - 1));
            for (int i = 0; i < top; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(new string('*', n - 2));
                    Console.Write("/ \\");
                    Console.WriteLine(new string('*', n - 2));
                }
                else
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write("/ \\");
                    Console.WriteLine(new string('-', n - 2));
                }
            }


        }
        static void PrintTopAsterix(int n)
        {
            Console.Write(new string('*', n - 2));
            Console.Write("\\ /");
            Console.WriteLine(new string('*', n - 2));
        }
        static void PrintTopDashes(int n)
        {
            Console.Write(new string('-', n - 2));
            Console.Write("\\ /");
            Console.WriteLine(new string('-', n - 2));
        }
        static void PrintBottomAsterix(int n)
        {
            Console.Write(new string('*', n - 2));
            Console.Write("/ \\");
            Console.WriteLine(new string('*', n - 2));
        }
        static void PrintBottomDashes(int n)
        {
            Console.Write(new string('-', n - 2));
            Console.Write("/ \\");
            Console.WriteLine(new string('-', n - 2));
        }
    }
}
