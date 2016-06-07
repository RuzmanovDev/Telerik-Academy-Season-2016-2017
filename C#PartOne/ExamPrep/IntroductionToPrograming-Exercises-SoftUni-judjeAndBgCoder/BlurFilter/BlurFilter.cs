namespace BlurFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BlurFilter
    {
        public static void Main(string[] args)
        {
            int blurAmount = int.Parse(Console.ReadLine());
            int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            long[,] matrix = new long[rows, cols];

            //read the matrix 
            int index = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                long[] nums = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = nums[c];
                    index++;

                }
                index--;
            }

            int[] coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int blurRow = coordinates[0];
            int blurCols = coordinates[1];


            matrix[blurRow, blurCols] += blurAmount;

            if (blurRow - 1 >= 0)
            {
                matrix[blurRow - 1, blurCols] += blurAmount; // top mid
                if (blurCols - 1 >= 0)
                {
                    matrix[blurRow - 1, blurCols - 1] += blurAmount; // top left
                }
                if (blurCols + 1 < cols) // top right ??
                {
                    matrix[blurRow - 1, blurCols + 1] += blurAmount;
                }
            }

            if (blurCols - 1 >= 0) // left
            {
                matrix[blurRow, blurCols - 1] += blurAmount;
            }

            if (blurCols + 1 < cols) // right
            {
                matrix[blurRow, blurCols + 1] += blurAmount;
            }

            if (blurRow + 1 < rows)
            {
                matrix[blurRow + 1, blurCols] += blurAmount; // bottom
                if (blurCols - 1 >= 0)
                {
                    matrix[blurRow+1, blurCols - 1] += blurAmount; // bottom left
                }

                if (blurCols + 1 < cols)
                {
                    matrix[blurRow+1, blurCols + 1] += blurAmount; // bottom right
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
