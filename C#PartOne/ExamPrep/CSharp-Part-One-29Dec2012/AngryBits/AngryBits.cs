namespace AngryBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AngryBits
    {
        public static void Main(string[] args)
        {
            char[,] field = new char[8, 16];
            string values = string.Empty;
            int pigsDestroyed = 0;
            int length = 0;
            int score = 0;
            for (int i = 0; i < 8; i++)
            {
                ushort number = ushort.Parse(Console.ReadLine());
                values += Convert.ToString(number, 2).PadLeft(16, '0');
            }
            int index = 0;

            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    field[r, c] = values[index];
                    index++;
                }
            }

            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    Console.Write(field[r, c] + " ");
                }
                Console.WriteLine();
            }

            {
                for (int r = 0; r < 8; r++)
                {
                    for (int c = 0; c < 8; c++)
                    {

                        if (field[r, c] == '1')
                        {
                            // bird is found 

                            int birdRow = r;
                            int birdCol = c;
                            field[birdRow, birdCol] = '0'; // destroy the bird
                            bool moveUp = false;
                            bool moveDown = false;
                            if (birdRow != '0') // move up
                            {
                                moveUp = true;
                            }
                            else // move down
                            {
                                moveDown = true;
                            }

                            while (moveUp)
                            {
                                birdRow--;
                                birdCol++;

                                if (birdRow > 7 || birdCol > 15)
                                {
                                    break;
                                }
                                if (field[birdRow, birdCol] == '1') // found pig
                                {
                                    field[birdRow, birdCol] = '0';
                                    pigsDestroyed++;
                                    score = score + length * pigsDestroyed;

                                    if (birdRow - 1 > 0 && field[birdRow - 1, birdCol] == '1') // destroy upPig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow - 1, birdCol] = '0';
                                        score = score + length * pigsDestroyed;

                                    }

                                    if (birdRow - 1 > 0 && birdCol - 1 > 7 && field[birdRow - 1, birdCol - 1] == '1') // destroy upleft
                                    {
                                        pigsDestroyed++;
                                        field[birdRow - 1, birdCol - 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow - 1 > 0 && birdCol + 1 <= 15 && field[birdRow - 1, birdCol + 1] == '1') //destroy up right
                                    {
                                        pigsDestroyed++;
                                        field[birdRow - 1, birdCol + 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow - 1 > 0 && birdCol - 1 > 7 && field[birdRow - 1, birdCol] == '1') // destroy left pig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow, birdCol] = '0';
                                        score = score + length * pigsDestroyed;
                                    }

                                    if (birdCol + 1 <= 15 && field[birdRow, birdCol + 1] == '1') // destroy right pig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow, birdCol + 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }

                                    if (birdRow + 1 <= 7 && field[birdRow + 1, birdCol] == '1') // destroy down pig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow + 1, birdCol] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow + 1 <= 7 && birdCol - 1 > 7 && field[birdRow + 1, birdCol - 1] == '1') // destroy downLeft
                                    {
                                        pigsDestroyed++;
                                        field[birdRow + 1, birdCol - 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow + 1 <= 7 && birdCol + 1 <= 15 && field[birdRow + 1, birdCol - 1] == '1') // downRight
                                    {
                                        pigsDestroyed++;
                                        field[birdRow + 1, birdCol - 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }

                                }
                                length++;
                               

                                if (birdRow == 0)
                                {
                                    moveUp = false;
                                    moveDown = true;


                                }

                            }
                            length = 0;
                            pigsDestroyed = 0;
                            while (moveDown)
                            {

                                //debug

                                birdRow++;
                                birdCol++;

                                if (birdRow > 7 || birdCol > 15)
                                {
                                    break;
                                }
                                //end


                                //copy

                                if (field[birdRow, birdCol] == '1') // found pig
                                {
                                    field[birdRow, birdCol] = '0';
                                    pigsDestroyed++;
                                    score = score + length * pigsDestroyed;

                                    if (birdRow - 1 > 0 && field[birdRow - 1, birdCol] == '1') // destroy upPig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow - 1, birdCol] = '0';
                                        score = score + length * pigsDestroyed;

                                    }

                                    if (birdRow - 1 > 0 && birdCol - 1 > 7 && field[birdRow - 1, birdCol - 1] == '1') // destroy upleft
                                    {
                                        pigsDestroyed++;
                                        field[birdRow - 1, birdCol - 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow - 1 > 0 && birdCol + 1 <= 15 && field[birdRow - 1, birdCol + 1] == '1') //destroy up right
                                    {
                                        pigsDestroyed++;
                                        field[birdRow - 1, birdCol + 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow - 1 > 0 && birdCol - 1 > 7 && field[birdRow - 1, birdCol] == '1') // destroy left pig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow, birdCol] = '0';
                                        score = score + length * pigsDestroyed;
                                    }

                                    if (birdCol + 1 <= 15 && field[birdRow, birdCol + 1] == '1') // destroy right pig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow, birdCol + 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }

                                    if (birdRow + 1 <= 7 && field[birdRow + 1, birdCol] == '1') // destroy down pig
                                    {
                                        pigsDestroyed++;
                                        field[birdRow + 1, birdCol] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow + 1 <= 7 && birdCol - 1 > 7 && field[birdRow + 1, birdCol - 1] == '1') // destroy downLeft
                                    {
                                        pigsDestroyed++;
                                        field[birdRow + 1, birdCol - 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }
                                    if (birdRow + 1 <= 7 && birdCol + 1 <= 15 && field[birdRow + 1, birdCol - 1] == '1') // downRight
                                    {
                                        pigsDestroyed++;
                                        field[birdRow + 1, birdCol - 1] = '0';
                                        score = score + length * pigsDestroyed;
                                    }

                                }
                                length++;
                                // paste
                              
                                if (birdRow == 7)
                                {
                                    moveUp = true;
                                    moveDown = false;
                                }
                            }
                        }
                    }


                }

                bool isWin = true;
                for (int r = 8; r < field.GetLength(0); r++)
                {
                    for (int c = 8; c < field.GetLength(1); c++)
                    {
                        if (field[r, c] == '1')
                        {
                            isWin = false;
                            break;
                        }
                    }
                }


                if (isWin)
                {
                    Console.WriteLine("Yes {0}", score);
                }
                else
                {
                    Console.WriteLine("No {0}", score);
                }
            }
        }
    }
}



