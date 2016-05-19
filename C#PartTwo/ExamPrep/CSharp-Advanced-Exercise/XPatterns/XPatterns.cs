namespace XPatterns
{
    using System;
    
    class XPatterns
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[,] matrix = new long[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i, j] = long.Parse(line[j]);
                }
            }

            long maxSum = long.MinValue;
            bool found = false;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                //long sum = 0;
                for (int col = 0; col < matrix.GetLength(1) - 4; col++)
                {
                    if (matrix[row, col] + 1 == matrix[row, col + 1] && matrix[row, col] + 2 == matrix[row, col + 2]
                        && matrix[row, col + 2] + 1 == matrix[row + 1, col + 2] && matrix[row, col + 2] + 2 == matrix[row + 2, col + 2]
                        && matrix[row + 2, col + 2] + 1 == matrix[row + 2, col + 3] && matrix[row + 2, col + 2] + 2 == matrix[row + 2, col + 4])
                    {
                        found = true;
                        long sum = CalculateSum(matrix, row, col);
                        maxSum = Math.Max(sum, maxSum);
                    }
                }
            }
            if (!found)
            {
                long sumOfMain = SumOfMainDiagonal(matrix);

                Console.WriteLine("NO {0}", sumOfMain);
            }
            else
            {
                Console.WriteLine("YES {0}", maxSum);

            }

        }
        static long SumOfMainDiagonal(long[,] matrix)
        {
            long sum = 0;
            int r = 0;
            int c = 0;

            while (r < matrix.GetLength(1))
            {
                sum += matrix[r, c];
                r++;
                c++;
            }
            return sum;
        }
        static long CalculateSum(long[,] matrix, int row, int col)
        {
            long sum = 0;
            sum += matrix[row, col];
            sum += matrix[row, col + 1];
            sum += matrix[row, col + 2];
            sum += matrix[row + 1, col + 2];
            sum += matrix[row + 2, col + 2];
            sum += matrix[row + 2, col + 3];
            sum += matrix[row + 2, col + 4];
            return sum;
        }
    }
}
