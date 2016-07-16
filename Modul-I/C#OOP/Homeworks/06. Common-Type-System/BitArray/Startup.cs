
namespace BitArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            var number = new BitArray(43);

            //check bits property
            int[] bits = number.Bits;

            for (int i = 0; i < bits.Length; i++)
            {
                Console.Write(bits[i]);
            }

            Console.WriteLine();

            //test enumerator
            foreach (var item in number)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            //check indexator
            Console.WriteLine(number[0]);
            Console.WriteLine(number[63]);
        }
    }
}
