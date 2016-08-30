using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class EntryPoint
    {
        public static void Main()
        {
            const int MaxSafeCells = 35;

            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] mines = PutMinesOnField();
            int visitedCells = 0;
            bool hasMineExploded = false;
            List<PlayerPoints> champions = new List<PlayerPoints>(6);
            int row = 0;
            int column = 0;
            bool startedNewGame = true;
            bool gameHasEnded = false;

            do
            {
                if (startedNewGame)
                {
                    Console.WriteLine(Constants.StartUpMessage);
                    Console.WriteLine(Constants.CommandsHelp);

                    DrawBoard(gameField);
                    startedNewGame = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= Constants.MaximumCommandLength)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = Constants.TurnCommand;
                    }
                }

                switch (command)
                {
                    case Constants.TopCommand:
                        WriteScoreBoard(champions);
                        break;
                    case Constants.RestartCommand:
                        gameField = CreateGameField();
                        mines = PutMinesOnField();
                        DrawBoard(gameField);
                        hasMineExploded = false;
                        startedNewGame = false;
                        break;
                    case Constants.ExitComamnd:
                        break;
                    case Constants.TurnCommand:
                        if (mines[row, column] != Constants.Asterix)
                        {
                            if (mines[row, column] == Constants.Dash)
                            {
                                NextTurn(gameField, mines, row, column);
                                visitedCells++;
                            }

                            if (MaxSafeCells == visitedCells)
                            {
                                gameHasEnded = true;
                            }
                            else
                            {
                                DrawBoard(gameField);
                            }
                        }
                        else
                        {
                            hasMineExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (hasMineExploded)
                {
                    DrawBoard(mines);
                    Console.Write(Constants.DeadMessage, visitedCells);

                    string nickName = Console.ReadLine();
                    PlayerPoints playerPoints = new PlayerPoints(nickName, visitedCells);
                    if (champions.Count < 5)
                    {
                        champions.Add(playerPoints);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].TotalPoints < playerPoints.TotalPoints)
                            {
                                champions.Insert(i, playerPoints);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((PlayerPoints r1, PlayerPoints r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((PlayerPoints r1, PlayerPoints r2) => r2.TotalPoints.CompareTo(r1.TotalPoints));
                    WriteScoreBoard(champions);

                    gameField = CreateGameField();
                    mines = PutMinesOnField();
                    visitedCells = 0;
                    hasMineExploded = false;
                    startedNewGame = true;
                }

                if (gameHasEnded)
                {
                    Console.WriteLine("\nCongratz!! You have opened 35 cells wihout finding any mine!");
                    DrawBoard(mines);
                    Console.WriteLine("What is your name, champ: ");
                    string nickName = Console.ReadLine();
                    PlayerPoints playerPoints = new PlayerPoints(nickName, visitedCells);
                    champions.Add(playerPoints);
                    WriteScoreBoard(champions);
                    gameField = CreateGameField();
                    mines = PutMinesOnField();
                    visitedCells = 0;
                    gameHasEnded = false;
                    startedNewGame = true;
                }
            }
            while (command != Constants.ExitComamnd);

            Console.WriteLine("Made in Bulgaria");
            Console.Read();
        }

        private static void WriteScoreBoard(List<PlayerPoints> points)
        {
            Console.WriteLine(Environment.NewLine + "Points:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} Boxes", i + 1, points[i].Name, points[i].TotalPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ScoarBoard" + Environment.NewLine);
            }
        }

        private static void NextTurn(char[,] gameField, char[,] bombs, int row, int col)
        {
            char howManyBombs = HowManyBombs(bombs, row, col);
            bombs[row, col] = howManyBombs;
            gameField[row, col] = howManyBombs;
        }

        private static void DrawBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int r = 0; r < rows; r++)
            {
                Console.Write("{0} | ", r);
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(string.Format("{0} ", board[r, c]));
                }

                Console.Write(Constants.Pipe);
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            const char BoardInitialSymbol = '?';
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int r = 0; r < boardRows; r++)
            {
                for (int c = 0; c < boardColumns; c++)
                {
                    board[r, c] = BoardInitialSymbol;
                }
            }

            return board;
        }

        private static char[,] PutMinesOnField()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    gameField[r, c] = Constants.Dash;
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random randomGenerator = new Random();
                int randomNum = randomGenerator.Next(50);
                if (!randomNumbers.Contains(randomNum))
                {
                    randomNumbers.Add(randomNum);
                }
            }

            foreach (int i2 in randomNumbers)
            {
                int col = (i2 / cols);
                int row = (i2 % cols);
                if (row == 0 && i2 != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = Constants.Asterix;
            }

            return gameField;
        }

        private static void Calculations(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int c = 0; c < col; c++)
            {
                for (int r = 0; r < row; r++)
                {
                    if (field[c, r] != Constants.Asterix)
                    {
                        char kolkoo = HowManyBombs(field, c, r);
                        field[c, r] = kolkoo;
                    }
                }
            }
        }

        private static char HowManyBombs(char[,] gameField, int row, int column)
        {
            int count = 0;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, column] == Constants.Asterix)
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (gameField[row + 1, column] == Constants.Asterix)
                {
                    count++;
                }
            }

            if (column - 1 >= 0)
            {
                if (gameField[row, column - 1] == Constants.Asterix)
                {
                    count++;
                }
            }

            if (column + 1 < cols)
            {
                if (gameField[row, column + 1] == Constants.Asterix)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (gameField[row - 1, column - 1] == Constants.Asterix)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < cols))
            {
                if (gameField[row - 1, column + 1] == Constants.Asterix)
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (gameField[row + 1, column - 1] == Constants.Asterix)
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < cols))
            {
                if (gameField[row + 1, column + 1] == Constants.Asterix)
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
