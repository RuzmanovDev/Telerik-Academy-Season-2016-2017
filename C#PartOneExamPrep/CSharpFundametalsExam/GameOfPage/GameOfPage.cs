namespace GameOfPage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class GameOfPage
    {
        static int cookies = 0;
        static StringBuilder answer = new StringBuilder();
        static void Main(string[] args)
        {
            char[,] matrix = new char[16, 16];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                string input = Console.ReadLine();
                sb.Append(input);
            }
            string allDigits = sb.ToString();
            int index = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = allDigits[index];
                    index++;
                }
            }
            //Console.WriteLine();
            //for (int r = 0; r < matrix.GetLength(0); r++)
            //{
            //    for (int c = 0; c < matrix.GetLength(1); c++)
            //    {
            //        Console.Write(matrix[r, c]);

            //    }
            //    Console.WriteLine();
            //}
            //return;

            string command = Console.ReadLine();
            int row = 0;
            int col = 0;

            while (!command.Equals("paypal"))
            {


                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());
                if (command.Equals("what is"))
                {
                    if (IsTheCookieWhole(matrix, row, col))
                    {
                        answer.AppendLine("cookie");
                    }
                    else if (IsTheCookieCrumb(matrix, row, col))
                    {
                        answer.AppendLine("cookie crumb");
                    }
                    else if (!IsTheCookieCrumb(matrix, row, col))
                    {
                        answer.AppendLine("broken cookie");
                    }
                }
                else if (command.Equals("buy"))
                {
                    if (IsNothing(matrix,row, col))
                    {
                        answer.AppendLine("smile");
                    }
                    else if (IsTheCookieWhole(matrix, row, col))
                    {
                        BuyCookie(matrix, row, col);
                    }
                    else
                    {
                        answer.AppendLine("page");
                    }

                }
                command = Console.ReadLine();

            }
            Console.WriteLine(answer.ToString());
            Console.WriteLine(cookies * 1.79);
        }
        static bool IsTheCookieWhole(char[,] matrix, int row, int col)
        {
            bool isWhole = true;
            try
            {
                for (int r = row - 1; r < row + 2; r++)
                {
                    for (int c = col - 1; c < col + 2; c++)
                    {
                        if (matrix[r, c] != '1')
                        {
                            isWhole = false;
                            return isWhole;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                isWhole = false;
            }

            return isWhole;
        }
        static bool IsTheCookieCrumb(char[,] matrix, int row, int col)
        {
            bool crumb = false;
            try
            {
                if (matrix[row, col] == '1'
                            && matrix[row - 1, col - 1] == '0'
                            && matrix[row - 1, col] == '0'
                            && matrix[row, col - 1] == '0'
                            && matrix[row - 1, col + 1] == '0'
                            && matrix[row, col + 1] == '0'
                            && matrix[row + 1, col - 1] == '0'
                            && matrix[row + 1, col] == '0'
                            && matrix[row + 1, col + 1] == '0')
                {
                    crumb = true;
                }
                return crumb;
            }
            catch (IndexOutOfRangeException)
            {

                return crumb;
            }
           

           
        }
        static void BuyCookie(char[,] matrix, int row, int col)
        {
            cookies++;
            for (int r = row - 1; r < row + 2; r++)
            {
                for (int c = col - 1; c < col + 2; c++)
                {
                    matrix[r, c] = '0';
                }
            }

        }
        static bool IsNothing(char[,] matrix, int row, int col)
        {
            bool isNothing = true;
            try
            {
                for (int r = row - 1; r < row + 2; r++)
                {
                    for (int c = col - 1; c < col + 2; c++)
                    {
                        if (matrix[r, c] != '1')
                        {
                            isNothing = false;
                            return isNothing;
                        }
                    }
                }
                
            }
            catch (IndexOutOfRangeException)
            {
                isNothing = true;
            }
            return isNothing;

        }
    }
}
