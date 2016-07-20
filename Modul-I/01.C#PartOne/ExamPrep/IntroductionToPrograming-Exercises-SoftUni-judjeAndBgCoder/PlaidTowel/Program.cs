using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaidTowel
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char bgSymbol = char.Parse(Console.ReadLine());
            char rhSymbol = char.Parse(Console.ReadLine());

            int topDots = n;
            int width = n * 4 + 1;
            int middleDots = width - (topDots * 2 + 2);

            //top static row
            Console.Write(new string(bgSymbol, topDots));
            Console.Write(rhSymbol);
            Console.Write(new string(bgSymbol, middleDots));
            Console.Write(rhSymbol);
            Console.WriteLine(new string(bgSymbol, topDots));

            //firstRomb
            topDots--;
            middleDots -= 2;
            int insideRombDots = 1;
            for (int i = 0; i < n*2-1; i++)
            {
                Console.Write(new string(bgSymbol, topDots));
                Console.Write(rhSymbol);
                Console.Write(new string(bgSymbol, insideRombDots));
                if (i < (n + 1) - 2 || i > (n + 1) - 2)
                {
                    Console.Write(rhSymbol);

                }


                Console.Write(new string(bgSymbol, middleDots));
                Console.Write(rhSymbol);
                Console.Write(new string(bgSymbol, insideRombDots));
                Console.Write(rhSymbol);
                Console.WriteLine(new string(bgSymbol, topDots));
                if (i < (n + 1) - 2)
                {
                    topDots--;
                    if (topDots <= 0)
                    {
                        topDots = 0;
                    }
                    middleDots -= 2;
                    if (middleDots < 0)
                    {
                        middleDots = 0;
                    }
                    insideRombDots += 2;
                }
                else if (i == (n + 1) - 2)
                {
                    middleDots = 1;
                    insideRombDots -= 2;
                    topDots++;
                }
                else
                {
                    topDots++;
                    insideRombDots -= 2;
                    middleDots += 2;
                }
            }

            //botom static row first part
            topDots = n;
            width = n * 4 + 1;
            middleDots = width - (topDots * 2 + 2);

            Console.Write(new string(bgSymbol, topDots));
            Console.Write(rhSymbol);
            Console.Write(new string(bgSymbol, middleDots));
            Console.Write(rhSymbol);
            Console.WriteLine(new string(bgSymbol, topDots));
            //// BLALA

            topDots--;
            middleDots -= 2;
            insideRombDots = 1;
            for (int i = 0; i < n*2-1; i++)
            {
                Console.Write(new string(bgSymbol, topDots));
                Console.Write(rhSymbol);
                Console.Write(new string(bgSymbol, insideRombDots));
                if (i < (n + 1) - 2 || i > (n + 1) - 2)
                {
                    Console.Write(rhSymbol);

                }


                Console.Write(new string(bgSymbol, middleDots));
                Console.Write(rhSymbol);
                Console.Write(new string(bgSymbol, insideRombDots));
                Console.Write(rhSymbol);
                Console.WriteLine(new string(bgSymbol, topDots));
                if (i < (n + 1) - 2)
                {
                    topDots--;
                    if (topDots <= 0)
                    {
                        topDots = 0;
                    }
                    middleDots -= 2;
                    if (middleDots < 0)
                    {
                        middleDots = 0;
                    }
                    insideRombDots += 2;
                }
                else if (i == (n + 1) - 2)
                {
                    middleDots = 1;
                    insideRombDots -= 2;
                    topDots++;
                }
                else
                {
                    topDots++;
                    insideRombDots -= 2;
                    middleDots += 2;
                }
            }
            topDots = n;
            width = n * 4 + 1;
            middleDots = width - (topDots * 2 + 2);
            Console.Write(new string(bgSymbol, topDots));
            Console.Write(rhSymbol);
            Console.Write(new string(bgSymbol, middleDots));
            Console.Write(rhSymbol);
            Console.WriteLine(new string(bgSymbol, topDots));

        }
    }
}
