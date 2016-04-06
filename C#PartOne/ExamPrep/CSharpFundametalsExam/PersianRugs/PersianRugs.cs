using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianRugs
{
    class PersianRugs
    {
        static void Main(string[] args)
        {
            // 55/100
            int n = int.Parse(Console.ReadLine());
            int numberOfSpaces = int.Parse(Console.ReadLine());

            int width = 2 * n + 1;
            int height = width;
            int innerDots = 3;
            int hashTagCounters = 0;
            int spacecountOutside = width - 2;
            int spacesToRightPart = width - (numberOfSpaces + 7);
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('#', hashTagCounters));
                Console.Write("\\");
                if (numberOfSpaces < n && innerDots > 0)
                {
                    Console.Write(new string(' ', numberOfSpaces));
                    Console.Write("\\");
                    Console.Write(new string('.', innerDots));
                    innerDots -= 2;
                    Console.Write("/");
                    Console.Write(new string(' ', numberOfSpaces));
                    spacecountOutside = width - 6;


                }
                if (numberOfSpaces > n || i > 1)
                {
                    Console.Write(new string(' ', spacecountOutside));
                    spacecountOutside -= 2;
                    if (spacecountOutside<0)
                    {
                        spacecountOutside = 0;
                    }
                }


                // Console.Write(new string(' ', spacecountOutside));
                Console.Write("/");
                Console.WriteLine(new string('#', hashTagCounters));
                hashTagCounters++;
            }

            Console.Write(new string('#', hashTagCounters));
            Console.Write("X");
            Console.WriteLine(new string('#', hashTagCounters));
            hashTagCounters--;
            int bottomSpace = 1;
            innerDots = 1;
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('#', hashTagCounters));
                Console.Write("/");
                if (i >numberOfSpaces+1)
                {
                    Console.Write(new string(' ', numberOfSpaces));
                    Console.Write("/");
                    Console.Write(new string('.', innerDots));
                    Console.Write("\\");
                    Console.Write(new string(' ', numberOfSpaces));
                    innerDots += 2;
                }
                else
                {
                    Console.Write(new string(' ', bottomSpace));
                }
                Console.Write("\\");
                Console.WriteLine(new string('#', hashTagCounters));
                hashTagCounters--;
                bottomSpace += 2;
            }
        }
    }
}
