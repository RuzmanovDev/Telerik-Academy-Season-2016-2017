using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesAndZeroes
{
    class OnesAndZeroes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string number = Convert.ToString(n, 2).PadLeft(32, '0');
           // Console.WriteLine(number);

            for (int i = 16; i < 32; i++)
            {
                if (number[i].Equals('0'))
                {
                    Console.Write("###");
                }
                else
                {
                    Console.Write(".#.");
                }
                if (i < 31)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            for (int i = 16; i < 32; i++)
            {
                if (number[i].Equals('0'))
                {
                    Console.Write("#.#");
                }
                else
                {
                    Console.Write("##.");
                }
                if (i < 31)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            for (int i = 16; i < 32; i++)
            {
                if (number[i].Equals('0'))
                {
                    Console.Write("#.#");
                }
                else
                {
                    Console.Write(".#.");
                }
                if (i < 31)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            for (int i = 16; i < 32; i++)
            {
                if (number[i].Equals('0'))
                {
                    Console.Write("#.#");
                }
                else
                {
                    Console.Write(".#.");
                }
                if (i < 31)
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine();
            for (int i = 16; i < 32; i++)
            {
                if (number[i].Equals('0'))
                {
                    Console.Write("###");
                }
                else
                {
                    Console.Write("###");
                }
                if (i < 31)
                {
                    Console.Write(".");
                }


            }
            Console.WriteLine();
        }
    }
}

