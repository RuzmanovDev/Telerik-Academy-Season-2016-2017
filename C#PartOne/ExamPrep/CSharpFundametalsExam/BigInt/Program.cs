using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BigInt
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());

            string numberAsStr = Convert.ToString((long)number, 2).PadLeft(64, '0');
            char[] numberAsArray = numberAsStr.ToCharArray();

            for (int i = 2; i < numberAsStr.Length; i++)
            {
                if (numberAsArray[i] == numberAsArray[i - 1] && numberAsArray[i - 2] == numberAsArray[i])
                {
                    if (numberAsStr[i] == '1')
                    {
                        numberAsArray[i] = '0';
                        numberAsArray[i - 1] = '0';
                        numberAsArray[i - 2] = '0';
                    }
                    else
                    {
                        numberAsArray[i] = '1';
                        numberAsArray[i - 1] = '1';
                        numberAsArray[i - 2] = '1';
                    }
                    i += 2;
                }




            }
            Console.WriteLine(Convert.ToUInt64(new string(numberAsArray), 2));

        }

    }
}
