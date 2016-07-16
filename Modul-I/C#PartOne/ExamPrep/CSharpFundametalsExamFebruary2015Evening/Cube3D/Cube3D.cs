namespace Cube3D
{
    using System;
    class Cube3D
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string(':', n));
            Console.WriteLine(" ");
            int widht = 2 * n - 1;
            int spaces = widht - n - 1;
            int lineCounter = 1;
            for (int i = 0; i < n-1; i++)
            {
                if (i == n - 2)
                {
                    Console.Write(new string(':', n));
                    Console.Write(new string('|', lineCounter));
                    Console.WriteLine(':');
                    break;
                }
                Console.Write(':');
                Console.Write(new string(' ', n - 2));
                Console.Write(':');
                if (i > 0)
                {
                    Console.Write(new string('|', lineCounter));
                    lineCounter++;
                }
                Console.Write(':');
                Console.WriteLine(new string(' ', spaces));
            }
            spaces = 1;

            lineCounter--;
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(new string(' ', spaces));
                Console.Write(':');
                Console.Write(new string('-', n - 2));
                Console.Write(':');
                Console.Write(new string('|', lineCounter));
                Console.WriteLine(':');
                spaces++;
                lineCounter--;
            }
            Console.Write(new string(' ', n));
            Console.WriteLine(new string(':', n));
        }
    }
}
