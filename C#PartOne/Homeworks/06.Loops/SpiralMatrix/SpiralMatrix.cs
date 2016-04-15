namespace SpiralMatrix
{
    using System;

    public class SpiralMatrix
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int row = 0;
            int col = 0;
            int value = 1;
            string direction = "right";

            for (int i = 0; i < n * n; i++)
            {
                if (direction == "right")
                {
                    matrix[row, col] = value;
                    col++;
                    value++;
                    if (col >= n)
                    {
                        col--;
                        row++;
                        direction = "down";
                    }
                    else if (matrix[row, col] != 0)
                    {
                        col--;
                        row++;
                        direction = "down";
                    }
                }
                else if (direction == "down")
                {
                    matrix[row, col] = value;
                    row++;
                    value++;
                    if (row >= n)
                    {
                        row--;
                        col--;
                        direction = "left";
                    }
                    else if (matrix[row, col] != 0)
                    {
                        row--;
                        col--;
                        direction = "left";
                    }
                }
                else if (direction == "left")
                {
                    matrix[row, col] = value;
                    col--;
                    value++;
                    if (col < 0)
                    {
                        row--;
                        col++;
                        direction = "up";
                    }
                    else if (matrix[row, col] != 0)
                    {
                        row--;
                        col++;
                        direction = "up";
                    }
                }
                else if (direction == "up")
                {
                    matrix[row, col] = value;
                    row--;
                    value++;
                    if (row < 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                    else if (matrix[row, col] != 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                }
            }

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
