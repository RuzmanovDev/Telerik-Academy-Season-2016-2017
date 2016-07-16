using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoverOfThree
{
    class LoverOfThree
    {
        static void Main(string[] args)
        {
            //fieldSize
            string input = Console.ReadLine();
            string[] sizeOfField = input.Split(' ');
            int rows = int.Parse(sizeOfField[0]);
            int cols = int.Parse(sizeOfField[1]);

            int[,] field = new int[rows, cols];

            for (int r = 0, e=0 ; r < field.GetLength(0); r++, e+=3)
            {
                for (int c = 0, d=0; c < field.GetLength(1); c++,d+=3)
                {
                    field[r, c] = (rows - 1) * 3 +d - e;

                }

            }


            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    Console.Write(String.Format("{0}\t", field[r, c]));


                }
                Console.WriteLine();
            }
        }
    }
}
