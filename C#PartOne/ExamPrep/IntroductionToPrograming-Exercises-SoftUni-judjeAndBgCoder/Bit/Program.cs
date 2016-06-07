using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int bitsCount = 0;
            int onesCount = 0;
            int zeroesCouunt = 0;

            while (n > 0)
            {
                Console.WriteLine(Convert.ToString(n, 2));
                bitsCount += n & 1;
                n >>= 1;
            }
            Console.WriteLine(bitsCount);
        }
    }
}
