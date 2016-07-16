using System;


namespace LoverOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rowsCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(rowsCols[0]);
            int cols = int.Parse(rowsCols[1]);

            int[,] matrix = new int[rows, cols];

            int valueOfMat = rows * 3;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                valueOfMat -= 3;
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = valueOfMat;
                    valueOfMat += 3;
                }
                valueOfMat -= 3 * cols;
            }

            int moves = int.Parse(Console.ReadLine());
            int counter = 0;
            int[] position = { rows - 1, 0 };
            int sum = 0;
            while (counter < moves)
            {
                string command = Console.ReadLine();
                string direction = command.Substring(0, 2);
                int lengthOfmove = int.Parse(command.Substring(3, command.Length - 3));

                while (lengthOfmove != 0)
                {
                    if (direction == "UR" || direction == "RU")
                    {


                        if (lengthOfmove != 1)
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                            position[0]--;
                            position[1]++;
                        }
                        else
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                        }
                        if (position[0] < 0)
                        {
                            position[0]++;
                            position[1]--;
                        }
                        if (position[1] > cols - 1)
                        {
                            position[1]--;
                            position[0]++;
                        }

                    }
                    if (direction == "DR" || direction == "RD")
                    {

                        if (lengthOfmove != 1)
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                            position[0]++;
                            position[1]++;
                        }
                        else
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                        }
                        if (position[0] > rows - 1)
                        {
                            position[0]--;
                            position[1]--;
                        }
                        if (position[1] > cols - 1)
                        {
                            position[1]--;
                            position[0]--;
                        }
                    }
                    if (direction == "DL" || direction == "LD")
                    {

                        if (lengthOfmove != 1)
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                            position[0]++;
                            position[1]--;
                        }
                        else
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                        }
                        if (position[0] > rows - 1)
                        {
                            position[0]--;
                            position[1]++;
                        }
                        if (position[1] < 0)
                        {
                            position[1]++;
                            position[0]--;
                        }
                    }
                    if (direction == "LU" || direction == "UL")
                    {
                        if (lengthOfmove != 1)
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                            position[0]--;
                            position[1]--;
                        }
                        else
                        {
                            sum += matrix[position[0], position[1]];
                            matrix[position[0], position[1]] = 0;
                        }
                        if (position[0] < 0)
                        {
                            position[0]++;
                            position[1]++;
                        }
                        if (position[1] < 0)
                        {
                            position[1]++;
                            position[0]++;
                        }
                    }

                    lengthOfmove--;
                }
                counter++;
            }
            Console.WriteLine(sum);

        }


    }
}
