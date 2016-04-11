using System;
using System.Collections.Generic;


namespace Qadranacci
{
    class Qadranacci
    {
        static void Main(string[] args)
        {
            List<long> elements = new List<long>();

            for (int i = 0; i < 4; i++)
            {
                long element = long.Parse(Console.ReadLine());
                elements.Add(element);

            }

            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows * columns; i++)
            {
                long nextElement = elements[elements.Count - 1] + elements[elements.Count - 2] + elements[elements.Count - 3] + elements[elements.Count - 4];
                elements.Add(nextElement);
            }

            long[,] result = new long[rows, columns];
            int index = 0;
            for (int r = 0; r < result.GetLength(0); r++)
            {
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    result[r, c] = elements[index];
                    index++;
                }
            }

            for (int r = 0; r < result.GetLength(0); r++)
            {
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    Console.Write(result[r, c] + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
