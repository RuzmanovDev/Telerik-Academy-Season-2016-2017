using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixOfPolindromes
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows, cols];

            char symbol = 'a';
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    string element = symbol.ToString() + (char)(symbol + c) + symbol.ToString();
                    matrix[r, c] = element;
                }
                symbol++;
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();

            }
        }
    }
}
