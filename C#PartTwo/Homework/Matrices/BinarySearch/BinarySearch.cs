using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());
            int seekedNumber = 0;

            Array.Sort(numbers);

            seekedNumber = Array.BinarySearch(numbers, k);
            if (seekedNumber == k)
            {
                Console.WriteLine("The seeked number is {0}", seekedNumber);
            }
            else
            {
                while (true)
                {
                    k--;
                    seekedNumber = Array.BinarySearch(numbers, k);
                    if (seekedNumber == k)
                    {
                        break;
                    }
                }
                Console.WriteLine("The seeked number is {0}", seekedNumber);

            }


        }
    }
}
