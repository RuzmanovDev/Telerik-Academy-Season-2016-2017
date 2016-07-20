using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichaniaBoats
{
    class KaspichaniaBoats
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n + 1;
            int height = 6 + ((n - 3) / 2) * 3;
            int topDots = n;

            Console.Write(new string('.',topDots));
            Console.Write('*');
            Console.WriteLine(new string('.',topDots));
            topDots--;
            Console.Write(new string('.', topDots));
            Console.Write(new string('*',3));
            Console.WriteLine(new string('.', topDots));
            topDots--;
            int inerDots = 1;

            for (int i = 0; i < n-2; i++)
            {
                Console.Write(new string('.', topDots));
                Console.Write('*');
                Console.Write(new string('.', inerDots));
                Console.Write('*');
                Console.Write(new string('.', inerDots));
                Console.Write('*');
                Console.WriteLine(new string('.', topDots));
                topDots--;
                inerDots++;
           
            }
            topDots = 1;
            inerDots--;
            Console.WriteLine(new string('*', width));

            int bottomPart = (n - 1) / 2;

            for (int i = 0; i < bottomPart; i++)
            { 
                Console.Write(new string('.', topDots));
                Console.Write('*');
                Console.Write(new string('.', inerDots));
                Console.Write('*');
                Console.Write(new string('.', inerDots));
                Console.Write('*');
                Console.WriteLine(new string('.', topDots));
                topDots++;
                inerDots--;

            }
            Console.Write(new string('.', topDots));
            Console.Write(new string('*', n));
            Console.WriteLine(new string('.', topDots));
        }
    }
}
