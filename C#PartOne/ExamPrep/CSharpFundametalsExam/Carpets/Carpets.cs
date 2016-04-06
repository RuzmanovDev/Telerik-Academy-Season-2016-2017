using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpets
{
    class Carpets
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int topDots = (n - 2) / 2;

            for (int i = 0; i < n / 2; i++)
            {
                if (i%2==0)
                {
                    Console.Write(new string('.',topDots));
                    Console.Write('/');
                    Console.Write('\\');
                    Console.WriteLine(new string('.', topDots));

                }
                else
                {
                    Console.Write(new string('.', topDots));
                    Console.Write('/');
                    Console.Write(new string(' ', 2));
                    Console.Write('\\');
                    Console.WriteLine(new string('.', topDots));
                }
                topDots--;
            }
        }
    }
}
