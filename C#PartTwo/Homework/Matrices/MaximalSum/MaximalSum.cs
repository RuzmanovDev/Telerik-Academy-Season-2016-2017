namespace MaximalSum
{
    using System;
    using System.Linq;

    class MaximalSum
    {
        static void Main(string[] args)
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

            long maxSum = long.MinValue;


            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    long sum = 0;

                    for (int row = r; row < r + 3; row++)
                    {
                        for (int col = c; col < c + 3; col++)
                        {
                            sum += matrix[row, col];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }

                    /*
                     *  sum += matrix[r, c]
                       + matrix[r, c + 1]
                       + matrix[r, c + 2]
                       + matrix[r + 1, c]
                       + matrix[r + 1, c + 1]
                       + matrix[r + 1, c + 2]
                       + matrix[r + 2, c]
                       + matrix[r + 2, c + 1]
                       + matrix[r + 2, c + 2];
*/
                }

            }
            Console.WriteLine(maxSum);

        }
    }
}
