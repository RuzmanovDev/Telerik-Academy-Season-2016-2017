namespace FillTheMatrix
{
    using System;

    class FillTheMatrix
    {
        static int value = 1;
        static void Print(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (c == matrix.GetLength(1) - 1)
                    {
                        Console.Write("{0}", matrix[r, c]);
                    }
                    else
                    {
                        Console.Write("{0} ", matrix[r, c]);

                    }
                }
                Console.WriteLine();
            }
        }
        static void FillA(int[,] matrix)
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
        static void FillB(int[,] matrix)
        {
            string dir = "down";
            int r = 0;

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                for (; r < matrix.GetLength(0) && r >= 0; r += dir == "down" ? +1 : -1)
                {
                    matrix[r, c] = value;
                    value++;
                }
                dir = dir == "up" ? dir = "down" : "up";
                if (dir == "up")
                {
                    r = matrix.GetLength(0) - 1;
                }
                else
                {
                    r = 0;
                }
            }
        }
        static void FillC(int[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1, index = 1; index <= matrix.GetLength(0) * matrix.GetLength(1); row--)
            {
                for (int currCol = (row >= 0 ? 0 : -row), currRow = (row >= 0 ? row : 0); currCol < (matrix.GetLength(1) - (row >= 0 ? row : 0));)
                {
                    matrix[currRow++, currCol++] = index++;
                }
            }
        }
        static void FillD(int[,] matrix)
        {
            string direction = "down";
            int row = -1, col = 0;

            for (int index = 1; index <= matrix.GetLength(0) * matrix.GetLength(1); index++)
            {
                if (direction == "down")
                {
                    if (matrix[++row, col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row + 1, col)) direction = "right";
                }
                else if (direction == "right")
                {
                    if (matrix[row, ++col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row, col + 1)) direction = "up";
                }
                else if (direction == "up")
                {
                    if (matrix[--row, col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row - 1, col)) direction = "left";
                }
                else if (direction == "left")
                {
                    if (matrix[row, --col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row, col - 1)) direction = "down";
                }
            }
        }
        static bool IsTraversable(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLongLength(0) &&
                   col >= 0 && col < matrix.GetLongLength(1) && matrix[row, col] == 0;
        }
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string method = Console.ReadLine();

            int[,] matrix = new int[size, size];
            switch (method)
            {
                case "a": FillA(matrix); break;
                case "b": FillB(matrix); break;
                case "c": FillC(matrix); break;
                case "d": FillD(matrix); break;

            }
            Print(matrix);

        }
    }
}
