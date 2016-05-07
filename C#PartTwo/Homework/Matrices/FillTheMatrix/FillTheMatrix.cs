using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string method = Console.ReadLine();

            int[,] matrix = new int[size, size];
            Fill(matrix, method);
            Print(matrix);

        }
        static void Print(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write("{0} ", matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
        static void Fill(int[,] matrix, string method)
        {
            int value = 1;

            if (method == "a")
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    for (int r = 0; r < matrix.GetLength(0); r++)
                    {
                        matrix[r, c] = value;
                        value++;
                    }
                }
            }
            else if (method == "b")
            {
                string dir = "down";
                int r = 0;
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    for (; r < matrix.GetLength(0); r += dir == "down" ? +1 : -1)
                    {
                        matrix[r, c] = value;
                        value++;
                    }
                    dir = dir == "up" ? dir = "down" : "up";
                }
            }
        }

    }
}
