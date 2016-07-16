namespace LargestAreaInMatrix
{
    using System;
    using System.Linq;

    class LargestAreaInMatrix
    {
        static bool[,] visited;
        static int[,] matrix;
        static int counter = 0;
        static int maxCounter = 0;
        static int rows; // .getLength is slow if it is out of a cycle!!!!
        static int cols;

        private static bool IsValidCell(int row, int col)
        {
            if (row < 0 || col < 0 || row >= rows || col >= cols || visited[row, col])
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void DFS(int row, int col, int element)
        {
            if (matrix[row, col] == element)
            {
                counter++;
                visited[row, col] = true;

                if (IsValidCell(row, col - 1))
                {
                    DFS(row, col - 1, element);
                }

                if (IsValidCell(row - 1, col))
                {
                    DFS(row - 1, col, element);
                }

                if (IsValidCell(row, col + 1))
                {
                    DFS(row, col + 1, element);
                }

                if (IsValidCell(row + 1, col))
                {
                    DFS(row + 1, col, element);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            rows = dimentions[0];
            cols = dimentions[1];
            matrix = new int[rows, cols];
            visited = new bool[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = line[c];

                }
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (!visited[r, c])
                    {
                        DFS(r, c, matrix[r, c]);

                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            // visited = new bool[rows, cols];
                        }
                        counter = 0;
                    }
                }
            }

            Console.WriteLine(maxCounter);
        }

    }
}
