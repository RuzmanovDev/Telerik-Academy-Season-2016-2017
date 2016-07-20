namespace Bit_Shift_Matrix
{
    using System;
    using System.Linq;
    using System.Numerics;

    class BitShiftMatrix
    {
        static void Main(string[] args)
        {
            var rowSCount = int.Parse(Console.ReadLine());
            var colsCount = int.Parse(Console.ReadLine());
            var n = Console.ReadLine();
            var collected = new bool[rowSCount, colsCount];
            var moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BigInteger sum = 0;
            var row = rowSCount - 1;
            var col = 0;
            BigInteger currentCellVallue = 1;
            var coeff = Math.Max(rowSCount, colsCount);

            foreach (var move in moves)
            {
                var nextRow = move / coeff;
                var nextCol = move % coeff;

                var deltaCol = col > nextCol ? -1 : 1;

                while (col != nextCol)
                {

                    if (!collected[row, col])
                    {
                        sum += currentCellVallue;
                        collected[row, col] = true;
                    }

                    if (deltaCol == 1)
                    {
                        currentCellVallue *= 2;
                    }
                    else
                    {
                        currentCellVallue /= 2;
                    }

                    col += deltaCol;
                }

                var deltaRow = row > nextRow ? -1 : 1;

                while (row != nextRow)
                {
                    if (!collected[row, col])
                    {
                        sum += currentCellVallue;
                        collected[row, col] = true;
                    }
                    if (deltaRow == 1)
                    {
                        currentCellVallue /= 2;

                    }
                    else
                    {
                        currentCellVallue *= 2;
                    }

                    row += deltaRow;
                }
            }

            if (!collected[row, col])
            {
                sum += currentCellVallue;
            }
            Console.WriteLine(sum);

        }
    }
}
