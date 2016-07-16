namespace MatrixOfLetters
{
    using System;

    public class MatrixOfLetters
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matirx = new char[rows, cols];

            char symbol = 'A';
            for (int r = 0; r < matirx.GetLength(0); r++)
            {
                for (int c = 0; c < matirx.GetLength(1); c++)
                {
                    matirx[r, c] = symbol;
                    symbol++;
                    if (symbol >= 'Z')
                    {
                        symbol = 'A';
                    }

                }
            }

            for (int r = 0; r < matirx.GetLength(0); r++)
            {
                for (int c = 0; c < matirx.GetLength(1); c++)
                {
                    Console.Write(matirx[r, c] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
