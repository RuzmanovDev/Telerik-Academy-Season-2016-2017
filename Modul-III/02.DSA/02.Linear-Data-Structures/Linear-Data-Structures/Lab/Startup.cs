using System;
using System.Collections.Generic;

namespace Lab
{
    public class Startup
    {
        static string[,] lab =
              {
                {" ","x","x"," "},
                {" "," "," ","x"},
                {" ","x"," "," "},
                {" "," ","x","x"},
                {" "," "," "," "},
            };

        static void Main()
        {
          
            var startCoords = new Coord(0, 0, 0);

            Queue<Coord> queue = new Queue<Coord>();
            queue.Enqueue(startCoords);

            while (queue.Count != 0)
            {
                var coords = queue.Dequeue();
                var row = coords.Row;
                var col = coords.Col;
                var value = coords.Value;

                if (IsInRange(row + 1, col) && lab[row + 1, col] == " ")
                {
                    lab[row + 1, col] = (value + 1).ToString();
                    queue.Enqueue(new Coord(row + 1, col, value + 1));
                }

                if (IsInRange(row - 1, col) && lab[row - 1, col] == " ")
                {
                    lab[row - 1, col] = (value + 1).ToString();
                    queue.Enqueue(new Coord(row - 1, col, value + 1));
                }


                if (IsInRange(row, col + 1) && lab[row, col + 1] == " ")
                {
                    lab[row, col + 1] = (value + 1).ToString();
                    queue.Enqueue(new Coord(row, col + 1, value + 1));
                }

                if (IsInRange(row, col - 1) && lab[row, col - 1] == " ")
                {
                    lab[row, col - 1] = (value + 1).ToString();
                    queue.Enqueue(new Coord(row, col - 1, value + 1));
                }

            }

            FillTheUnreachableCells();
            PrintPath(lab);
        }

        private static void FillTheUnreachableCells()
        {
            for (int r = 0; r < lab.GetLength(0); r++)
            {
                for (int c = 0; c < lab.GetLength(1); c++)
                {
                    if (lab[r, c] == " ")
                    {
                        lab[r, c] = "U";
                    }
                }
            }
        }

        static bool IsInRange(int x, int y)
        {
            if (x < 0 || x >= lab.GetLength(0) || y < 0 || y >= lab.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void PrintPath(string[,] path)
        {
            for (int r = 0; r < path.GetLength(0); r++)
            {
                for (int c = 0; c < path.GetLength(1); c++)
                {
                    Console.Write(path[r, c] + "   ");
                }

                Console.WriteLine();
            }
        }
    }
}