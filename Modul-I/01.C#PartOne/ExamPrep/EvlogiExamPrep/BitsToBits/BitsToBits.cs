using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsToBits
{
    class BitsToBits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                for (int j = 29; j >= 0; j--)
                {
                    int bit = ((1 << 29) & num) >> 29;
                }
                

            }
        }
    }
}
