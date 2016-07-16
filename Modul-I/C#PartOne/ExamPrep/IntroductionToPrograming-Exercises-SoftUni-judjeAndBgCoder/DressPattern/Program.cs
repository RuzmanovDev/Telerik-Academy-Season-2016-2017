using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 12 * n + 2;
            char underScore = '_';
            char dot = '.';
            char asterix = '*';
            char o = 'o';


            int underScoreCount = n * 4;
            int asteriCount = 2;

            Console.Write(new string(underScore, underScoreCount));
            Console.Write(dot);
            Console.Write(new string(underScore, underScoreCount));
            Console.Write(dot);
            Console.WriteLine(new string(underScore, underScoreCount));
            underScoreCount -= 2;

            for (int i = 0; i < 2 * n - 1; i++)
            {
                Console.Write(new string(underScore, underScoreCount));
                Console.Write(dot);
                Console.Write(new string(asterix, asteriCount));
                Console.Write(dot);
                Console.Write(new string(underScore, underScoreCount));
                Console.Write(dot);
                Console.Write(new string(asterix, asteriCount));
                Console.Write(dot);
                Console.WriteLine(new string(underScore, underScoreCount));
                underScoreCount -= 2;
                asteriCount += 3;
            }

            asteriCount = width - 2;
            Console.Write(dot);
            Console.Write(new string(asterix, asteriCount / 2 - 1));
            Console.Write("..");
            Console.Write(new string(asterix, asteriCount / 2 - 1));
            Console.WriteLine(dot);
            for (int i = 0; i < n; i++)
            {
                Console.Write(dot);
                Console.Write(new string(asterix, asteriCount));
                Console.WriteLine(dot);
            }

            int dotCount = n * 4 - 2;
            asteriCount = width - (2 * dotCount);
            Console.Write(new string(dot, dotCount));
            Console.Write(new string(asterix, asteriCount));
            Console.WriteLine(new string(dot, dotCount));

            underScoreCount = dotCount;
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string(underScore, underScoreCount));
                Console.Write(new string(o, asteriCount));
                Console.WriteLine(new string(underScore, underScoreCount));

            }
         
            asteriCount -= 2;
            for (int i = 0; i < n * 3; i++)
            {
                Console.Write(new string(underScore, underScoreCount));
                Console.Write(dot);
                Console.Write(new string(asterix, asteriCount));
                Console.Write(dot);
                Console.WriteLine(new string(underScore, underScoreCount));
                asteriCount += 2;
                underScoreCount--;
            }
            Console.WriteLine(new string(dot, width));
        }
    }
}
