using System;
using System.Linq;

class LargestAreaInMatrix
{
    static int[,] matrix;
    static int bestLength = 0;
    static int currentLength = 0, currentNumber = 0;
    static bool[,] visited;

    static void Main()
    {
        ReadInpit();
        FindBestAreaLength(matrix);
    }

    private static void ReadInpit()
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
    }

    static void FindBestAreaLength(int[,] testMatrix)
    {
        for (int row = 0; row < testMatrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < testMatrix.GetLongLength(1); col++)
            {
                if (!visited[row, col])
                {
                    currentNumber = testMatrix[row, col];
                    currentLength = 0;

                    GetAreaLength(row, col);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                    }
                }
            }
        }

        Console.WriteLine(bestLength);
    }

    static void GetAreaLength(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLongLength(0) ||
            col < 0 || col >= matrix.GetLongLength(1))
        {
            return;
        }
        if (visited[row, col])
        {
            return;
        }

        if (matrix[row, col] == currentNumber)
        {
            visited[row, col] = true;
            currentLength++;

            GetAreaLength(row - 1, col);
            GetAreaLength(row + 1, col);
            GetAreaLength(row, col - 1);
            GetAreaLength(row, col + 1);
        }
    }
}