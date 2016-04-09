namespace FormulaBit
{
    using System;

    class FormulaBit
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];
            string valuesOfMatrix = "";
            bool cantTurn = false;
            for (int i = 0; i < 8; i++)
            {
                int input = int.Parse(Console.ReadLine());
                valuesOfMatrix += Convert.ToString(input, 2).PadLeft(8, '0');
            }

            //fill the matrix with values 
            int currentChar = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = valuesOfMatrix[currentChar];
                    currentChar++;
                }
            }



            int startRow = 0;
            int startCol = matrix.GetLength(1) - 1;
            int lengthOfTheTrack = 0;
            int numberOfTurns = 0;
            while (matrix[startRow, startCol] != '1')
            {

                //move sout row++
                if (matrix[startRow, startCol] == '0')
                {
                    while (matrix[startRow, startCol] != '1')
                    {
                        lengthOfTheTrack++;
                        startRow++;
                        if (startRow > 7)
                        {
                            startRow--;
                            break;
                        }
                    }
                    if (matrix[startRow, startCol] == '1')
                    {
                        startRow--;
                    }

                    //chech if i am at the end of the track or if i can turn in the next direction  
                    if (isTheEnd(startRow, startCol) || startCol <= 0) // if it does NOT break the cyle i CAN MOVE in the next direction
                    {
                        break;
                    }
                    else if (matrix[startRow, startCol - 1] == '1')
                    {
                        cantTurn = true;
                        break;
                    }

                    //MOVE WEST 
                    startCol--;
                    numberOfTurns++;
                    while (matrix[startRow, startCol] != '1')
                    {
                        lengthOfTheTrack++;
                        startCol--;
                        if (startCol < 0)
                        {
                            startCol++;
                            break;
                        }
                    }
                    if (matrix[startRow, startCol] == '1')
                    {
                        startCol++;
                    }

                    //chech if i am at the end of the track or if i can turn in the next direction
                    if (isTheEnd(startRow, startCol) || startRow < 0)
                    {
                        break;
                    }
                    else if (matrix[startRow - 1, startCol] == '1')
                    {
                        cantTurn = true;
                        break;
                    }

                    // MOVE NORTH
                    startRow--;
                    numberOfTurns++;

                    while (matrix[startRow, startCol] != '1')
                    {
                        lengthOfTheTrack++;
                        startRow--;
                        if (startRow < 0)
                        {
                            startRow++;
                            break;
                        }
                    }
                    if (matrix[startRow, startCol] == '1')
                    {
                        startRow--;
                    }

                    //chech if i am at the end of the track or if i can turn in the next direction  ???????????
                    if (isTheEnd(startRow, startCol) || startCol <= 0)
                    {
                        break;
                    }
                    else if (matrix[startRow, startCol - 1] == '1')
                    {
                        cantTurn = true;
                        break;
                    }
                    //MOVE WEST
                    startCol--;
                    numberOfTurns++;

                    while (matrix[startRow, startCol] != '1')
                    {
                        lengthOfTheTrack++;
                        startCol--;
                        if (startCol < 0)
                        {
                            startCol++;
                            break;
                        }
                    }
                    if (matrix[startRow, startCol] == '1')
                    {
                        startCol++;
                    }
                    if (isTheEnd(startRow, startCol) || startRow > 7) // if it does NOT break the cyle i CAN MOVE in the next direction
                    {
                        break;
                    }
                    else if (matrix[startRow + 1, startCol] == '1')
                    {
                        cantTurn = true;
                        break;
                    }
                    startRow++;
                    numberOfTurns++;
                }

            }
            if (cantTurn)
            {
                Console.WriteLine("No " + lengthOfTheTrack);
            }
            else
            {
                Console.WriteLine(lengthOfTheTrack + " " + numberOfTurns);

            }


        }

        static bool isTheEnd(int startRow, int startCol)
        {
            if (startRow == 7 && startCol == 7)
            {
                return true;
            }
            return false;
        }
    }
}
