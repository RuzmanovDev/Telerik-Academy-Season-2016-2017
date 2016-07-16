using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestFrameInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] currentLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currentLine[c];
                }
            }

            int row = 0;
            int col = 0;

            int colsCount = 0;
            int rowsCount = 0;

            bool moveRight = false;
            bool moveDown = false;
            bool moveLeft = false;
            bool moveUp = false;
            List<string> frames = new List<string>();

            while (true)
            {
                if (col < matrix.GetLength(1))
                {
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        moveRight = true;
                    }
                }
                if (moveRight)
                {
                    if (col < matrix.GetLength(0) - 1) // check if we are out of range
                    {
                        col++;
                        rowsCount = 1;
                        colsCount++;
                        continue;
                    }
                    else
                    {
                        if (matrix[row, col] == matrix[row + 1, col]) // if the bottom element is equal continue checkin down side
                        {
                            moveRight = false;
                            moveDown = true;
                        }
                        else
                        {
                            frames.Add(colsCount + "x" + rowsCount);
                        }
                    }

                }

                if (moveDown)
                {
                    if (row < matrix.GetLength(1) - 1)
                    {
                        row++;
                        continue;
                    }
                }


                if (moveLeft)
                {
                    if (col > 0)
                    {
                        col--;
                        continue;
                    }
                }

                if (moveUp)
                {
                    if (row > 0)
                    {
                        row--;
                        continue;
                    }
                }

                col++;

            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                //int[] currentLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
