namespace MatrixOfNumbers
{
    using System;

    public class MatrixOfNumbers
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int value = r + 1;
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = value;
                    value++;
                }
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
