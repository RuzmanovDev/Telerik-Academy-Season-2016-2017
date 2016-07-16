using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitShiftMatrix
{
    class BitShiftMatrix
    {
        static void Main(string[] args)
        {

            //input
            long rows = long.Parse(Console.ReadLine());
            long cols = long.Parse(Console.ReadLine());
            long numberOfMoves = long.Parse(Console.ReadLine());
            string[] codesAsString = Console.ReadLine().Split(' ');
            long[] codes = Array.ConvertAll(codesAsString, n => long.Parse(n));
            long coeff = Math.Max(rows, cols);

            BigInteger[,] matrix = new BigInteger[rows, cols];
            //filling up the matrix
            BigInteger value = 1;
            BigInteger tempValue = 0;
            for (long r = matrix.GetLength(0) - 1; r >= 0; r--)
            {
                for (long c = 0; c < matrix.GetLength(1); c++)
                {
                    if (c == 0)
                    {
                        tempValue = value;
                    }
                    matrix[r, c] = value;
                    value *= 2;

                }
                value = tempValue;
                value *= 2;
            }


            //for (long r = 0; r < matrix.GetLength(0); r++)
            //{
            //    for (long c = 0; c < matrix.GetLength(1); c++)
            //    {
            //        Console.Write(matrix[r, c] + " ");
            //    }
            //    Console.WriteLine();
            //}

            long[] currentPosition = new long[2];
            long sartRow = rows - 1;
            long startCol = 0;
            currentPosition[0] = sartRow;
            currentPosition[1] = startCol;
            BigInteger sum = new BigInteger();
            long[] nextPosition = new long[2];
            for (long i = 0; i < numberOfMoves; i++)
            {

                //find next position
                long currentCode = codes[i];
                nextPosition = FindNextPosition(currentCode, coeff);
                long cycleBoundary = Math.Abs(nextPosition[1] - currentPosition[1]);
                for (long k = 0; k <= cycleBoundary; k++) // goes to the target column
                {
                    sum += matrix[currentPosition[0], currentPosition[1]];
                    matrix[currentPosition[0], currentPosition[1]] = 0;
                    if (currentPosition[1] < nextPosition[1])
                    {
                        currentPosition[1]++;
                    }
                    else if (currentPosition[1] > nextPosition[1])
                    {
                        currentPosition[1]--;
                    }
                }
                currentPosition[1] = nextPosition[1];
                // goes to the target row
                cycleBoundary = Math.Abs(nextPosition[0] - currentPosition[0]);
                for (long j = 0; j <= cycleBoundary; j++) // goes to the target column
                {
                    sum += matrix[currentPosition[0], currentPosition[1]];
                    matrix[currentPosition[0], currentPosition[1]] = 0;
                    if (currentPosition[0] < nextPosition[0])
                    {
                        currentPosition[0]++;
                    }
                    else if (currentPosition[0] > nextPosition[0])
                    {
                        currentPosition[0]--;
                    }
                }
                currentPosition[0] = nextPosition[0];
            }

            Console.WriteLine(sum);

        }

        private static long[] FindNextPosition(long currentCode, long coeff)
        {
            long[] newPostion = new long[2];
            newPostion[0] = currentCode / coeff;
            newPostion[1] = currentCode % coeff;
            return newPostion;
        }
    }
}

