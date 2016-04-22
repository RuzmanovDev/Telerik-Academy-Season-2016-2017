using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBasic
{
    class BasicBasic
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "RUN")
                {
                    break;
                }
                Console.WriteLine(string.Join(" ", input));

            }

        }
    }
}
