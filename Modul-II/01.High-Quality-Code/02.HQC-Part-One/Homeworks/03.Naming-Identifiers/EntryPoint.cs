using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class EntryPoint
    {
        const char Asterix = '*';
        const char Pipe = '|';
        const char Dash = '-';
        const string StartUpMessage = "Let's play \"Mines\". Try to find field withoud mine in it.";
        const string CommandsHelp = "Command 'top' shows the scoarboard, 'restart' begins a new game , 'exit' exits the game!";
        const string DeadMessage = "\nHrrrrrr! You have died! Your score is: {0} points. What is your name: ";
        const string TopCommand = "top";
        const string TurnCommand = "turn";
        const string RestartCommand = "restart";
        const string ExitComamnd = "exit";
        static void Main()
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] mines = PutMinesOnField();
            int counter = 0;
            bool hasMineExploded = false;
            List<Points> champions = new List<Points>(6);
            int row = 0;
            int column = 0;
            bool startedNewGame = true;
            const int maks = 35;
            bool gameHasEnded = false;

            do
            {
                if (startedNewGame)
                {
                    Console.WriteLine(StartUpMessage);
                    Console.WriteLine(CommandsHelp);

                    Draw(gameField);
                    startedNewGame = false;
                }
                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = TurnCommand;
                    }
                }
                switch (command)
                {
                    case "top":
                        ScoreBoard(champions);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        mines = PutMinesOnField();
                        Draw(gameField);
                        hasMineExploded = false;
                        startedNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case TurnCommand:
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                NextTurn(gameField, mines, row, column);
                                counter++;
                            }
                            if (maks == counter)
                            {
                                gameHasEnded = true;
                            }
                            else
                            {
                                Draw(gameField);
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
                    Draw(mines);
                    Console.Write("\nHrrrrrr! You have died! Your score is: {0} points. " +
                        "What is your name: ", counter);

                    string nickName = Console.ReadLine();
                    Points t = new Points(nickName, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].TotalPoints < t.TotalPoints)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Points r1, Points r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Points r1, Points r2) => r2.TotalPoints.CompareTo(r1.TotalPoints));
                    ScoreBoard(champions);

                    gameField = CreateGameField();
                    mines = PutMinesOnField();
                    counter = 0;
                    hasMineExploded = false;
                    startedNewGame = true;
                }
                if (gameHasEnded)
                {
                    Console.WriteLine("\nCongratz!! You have opened 35 cells wihout finding any mine!");
                    Draw(mines);
                    Console.WriteLine("What is your name, champ: ");
                    string nickName = Console.ReadLine();
                    Points to4kii = new Points(nickName, counter);
                    champions.Add(to4kii);
                    ScoreBoard(champions);
                    gameField = CreateGameField();
                    mines = PutMinesOnField();
                    counter = 0;
                    gameHasEnded = false;
                    startedNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.Read();
        }

        private static void ScoreBoard(List<Points> points)
        {
            Console.WriteLine(Environment.NewLine + "Points:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, points[i].Name, points[i].TotalPoints);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ScoarBoard" + Environment.NewLine);
            }
        }

        private static void NextTurn(char[,] gameField,
            char[,] bombs, int row, int col)
        {
            char howManyBombs = HowManyBombs(bombs, row, col);
            bombs[row, col] = howManyBombs;
            gameField[row, col] = howManyBombs;
        }

        private static void Draw(char[,] board)
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
                Console.Write("|");
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
                    gameField[r, c] = '-';
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

                gameField[col, row - 1] = '*';
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
                    if (field[c, r] != '*')
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
                if (gameField[row - 1, column] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (gameField[row + 1, column] == '*')
                {
                    count++;
                }
            }
            if (column - 1 >= 0)
            {
                if (gameField[row, column - 1] == '*')
                {
                    count++;
                }
            }
            if (column + 1 < cols)
            {
                if (gameField[row, column + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (gameField[row - 1, column - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (column + 1 < cols))
            {
                if (gameField[row - 1, column + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (gameField[row + 1, column - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (column + 1 < cols))
            {
                if (gameField[row + 1, column + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}
