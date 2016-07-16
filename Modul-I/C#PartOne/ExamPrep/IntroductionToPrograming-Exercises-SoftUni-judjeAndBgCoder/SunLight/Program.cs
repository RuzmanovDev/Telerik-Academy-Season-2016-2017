using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char dot = '.';
            char asterix = '*';

            int topDOts = (3 * n - 1)/2;

            Console.Write(new string(dot,topDOts)); 
            Console.Write(asterix);
            Console.WriteLine(new string(dot,topDOts));

            int middleDots = topDOts - 2;
            topDOts = 1;
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(new string(dot, topDOts)); 
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.WriteLine(new string(dot, topDOts));
                topDOts++;
                middleDots--;
            }

            topDOts = n;
            for (int i = 0; i < n/2; i++)
            {
                Console.Write(new string(dot, topDOts));
                Console.Write(new string(asterix, topDOts));
                Console.WriteLine(new string(dot, topDOts));
            }
            Console.WriteLine(new string(asterix, n*3));
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string(dot, topDOts));
                Console.Write(new string(asterix, topDOts));
                Console.WriteLine(new string(dot, topDOts));
            }

            middleDots++;
            topDOts--;
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(new string(dot, topDOts));
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.Write(new string(dot, middleDots));
                Console.Write(asterix);
                Console.WriteLine(new string(dot, topDOts));
                topDOts--;
                middleDots++;
            }
            topDOts = (3 * n - 1) / 2;
            Console.Write(new string(dot, topDOts));
            Console.Write(asterix);
            Console.WriteLine(new string(dot, topDOts));
        }
    }
}
