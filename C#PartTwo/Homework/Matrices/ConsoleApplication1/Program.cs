using System;
using System.Linq;

//We are given a matrix of strings of size N x M. Sequences in the matrix we define 
//as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.

namespace _03.SequencNMatrix
{
    class SequencNMatrix
    {
        static int max = 0;
        static int current = 1;
        static string element = " ";
        static string position = " ";

        static void Main()
        {
           
            int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];
            int[,] matrix = new int[rows, cols];
          

            for (int r = 0; r < rows; r++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = line[c];

                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    RightCheck(matrix, row, col);
                    DownCheck(matrix, row, col);
                    DiagonalCheck(matrix, row, col);
                }
            }
            
          
            Console.WriteLine(max);
        }

        private static void DiagonalCheck(int[,] matrix, int row, int col)
        {
            for (int i = row, j = col; i < matrix.GetLength(0) - 1 && j < matrix.GetLength(1) - 1; i++, j++)
            {
                if (matrix[i, j] == matrix[i + 1, j + 1])
                {
                    current++;

                    if (max < current)
                    {
                        max = current;
                       // element = matrix[i, j];
                        position = "diagonally";
                    }
                }
                else
                {
                    current = 1;
                    continue;
                }
            }

            current = 1;
        }

        private static void DownCheck(int[,] matrix, int row, int col)
        {
            for (int j = col; j < matrix.GetLength(1); j++)
            {
                for (int i = row; i < matrix.GetLength(0) - 1; i++)
                {
                    if (matrix[i, j] == matrix[i + 1, j])
                    {
                        current++;

                        if (max < current)
                        {
                            max = current;
                            //element = matrix[i, j];
                            position = "vertically";
                        }
                    }
                    else
                    {
                        current = 1;
                        continue;
                    }
                }
            }
            current = 1;
        }

        private static void RightCheck(int[,] matrix, int row, int col)
        {
            for (int i = row; i < matrix.GetLength(0); i++)
            {
                for (int j = col; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        current++;

                        if (max < current)
                        {
                            max = current;
                           // element = matrix[i, j];
                            position = "horizontally";
                        }
                    }
                    else
                    {
                        current = 1;
                        continue;
                    }
                }
            }
            current = 1;
        }
    }
}
