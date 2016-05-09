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

        static void DFS(int row, int col, int element)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            if (matrix[row, col] == element)
            {
                counter++;
            }
            else
            {
                return;
            }

            DFS(row, col - 1, element);
            DFS(row - 1, col, element);
            DFS(row, col + 1, element);
            DFS(row + 1, col, element);
        }

        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];
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
                            visited = new bool[rows, cols];
                        }
                        counter = 0;
                    }
                }
            }

            Console.WriteLine(maxCounter);
        }
        
    }
}
