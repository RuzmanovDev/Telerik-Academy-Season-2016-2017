namespace KukataIsDancing
{
    using System;

    class KukataIsDancing
    {
        static void Main(string[] args)
        {
            string[,] field =
            {
                {"RED","BLUE","RED" },
                {"BLUE","GREEN","BLUE" },
               { "RED","BLUE","RED" }

            };

            int[] rowsUpdate = { 0, -1, 0, 1 };
            int[] colsUpdate = { 1, 0, -1, 0 };

            int moves = int.Parse(Console.ReadLine());

            for (int i = 0; i < moves; i++)
            {
                string movesPath = Console.ReadLine();
                string position = field[1, 1];
                int row = 1;
                int col = 1;
                int dirRows = rowsUpdate[0]; // start moving towards blue square by default 
                int dirCols = colsUpdate[0];
                // magic
                int dirIndex = 0;
                for (int j = 0; j < movesPath.Length; j++)
                {
                    char move = movesPath[j];

                    if (move == 'L')
                    {
                        dirIndex += 1;
                        dirIndex = dirIndex > 3 ? 0 : dirIndex;
                        dirRows = rowsUpdate[dirIndex];
                        dirCols = colsUpdate[dirIndex];

                    }
                    else if (move == 'R')
                    {
                        dirIndex -= 1; ;
                        dirIndex = dirIndex < 0 ? 3 : dirIndex;
                        dirRows = rowsUpdate[dirIndex];
                        dirCols = colsUpdate[dirIndex];

                    }
                    else // proceed with W
                    {
                        //move
                        row += dirRows;
                        row = row < 0 ? 2 : row;
                        row = row > 2 ? 0 : row;

                        col += dirCols;
                        col = col < 0 ? 2 : col;
                        col = col > 2 ? 0 : col;

                        position = field[row, col];
                    }
                }

                Console.WriteLine(position);
            }
        }
    }
}