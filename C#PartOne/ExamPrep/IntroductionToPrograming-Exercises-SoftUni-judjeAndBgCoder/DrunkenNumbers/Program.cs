using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int mitkoTotal = 0;
            int vladkoTotal = 0; //could be Macedonian 


            for (int i = 0; i < n; i++)
            {
                int drunkerNumber = int.Parse(Console.ReadLine());
                if (drunkerNumber<0)
                {
                    drunkerNumber = -drunkerNumber;
                }
                // TODO: parse left ad right digits 
                int digitsCount = 0;
                int x = drunkerNumber;

                while (x > 0)
                {
                    digitsCount++;
                    x /= 10;
                }
                x = drunkerNumber;
                if (digitsCount % 2 == 0)
                {
                    for (int j = 0; j < digitsCount / 2; j++)
                    {
                        vladkoTotal += x % 10;
                        x /= 10;
                    }
                    for (int j = 0; j < digitsCount / 2; j++)
                    {
                        mitkoTotal += x % 10;
                        x /= 10;
                    }
                }
                else
                {
                    for (int j = 0; j < digitsCount / 2 + 1; j++)
                    {
                        vladkoTotal += x % 10;
                        if (j != digitsCount)
                        {
                            x /= 10;
                        }

                    }
                    for (int j = 0; j < digitsCount / 2 + 1; j++)
                    {
                        mitkoTotal += x % 10;
                        x /= 10;
                    }
                }
            }
            // OutPut

            if (mitkoTotal > vladkoTotal)
            {
                Console.WriteLine("M {0}", mitkoTotal - vladkoTotal);
            }
            else if (mitkoTotal < vladkoTotal)
            {
                Console.WriteLine("V {0}", vladkoTotal - mitkoTotal);
            }
            else
            {
                Console.WriteLine("No {0}", vladkoTotal + mitkoTotal);
            }

        }
    }
}
