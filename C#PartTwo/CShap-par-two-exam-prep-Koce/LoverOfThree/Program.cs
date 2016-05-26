using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoverOfThree
{
    class Program
    {
        // 1. read field sizes and create grid
        // 2. read directions
        // 2.1 go in that direction untill possible
        // 2,2,2 keep information if we  have visitted the cell
        // 2.2 sum cells on the way using rhe formula
        // 2.3 read another direction

        static void Main(string[] args)
        {
            var fieldSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rowsCount = fieldSizes[0];
            var colsCoun = fieldSizes[1];

        }
    }
}
