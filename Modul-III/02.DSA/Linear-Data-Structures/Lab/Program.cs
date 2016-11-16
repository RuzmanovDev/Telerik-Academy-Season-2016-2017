using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Program
    {
        static string[,] lab =
            {
                {" ","*"," "," "," "," ","*"," "," "},
                {" "," "," ","*"," "," ","*"," "," "},
                {" ","*"," "," "," "," "," "," ","*"},
                {" "," ","*","*"," ","*"," "," ","*"},
                {" "," "," "," "," "," "," "," "," "},
            };

        static int num = 0;

        static void FindPath(int row, int col, char direction)
        {
            if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
            {
                return;
            }

            lab[row, col] = num.ToString();
            num++;

            // Check if we have found the exit
            //if (lab[row, col] != " ")
            //{
            //    PrintPath(lab);
            //}

            if (lab[row, col] == " ")
            {
                lab[row, col] = num.ToString();

                FindPath(row, col - 1, 'L'); 
                FindPath(row - 1, col, 'U');
                FindPath(row, col + 1, 'R'); 
                FindPath(row + 1, col, 'D'); 
            }
        }

        static void PrintPath(string[,] path)
        {
            for (int r = 0; r < path.GetLength(0); r++)
            {
                for (int c = 0; c < path.GetLength(1); c++)
                {
                    Console.Write(path[r, c]);
                }

                Console.WriteLine();
            }
        }
        static void Main()
        {
            FindPath(0, 0, 'S');
            PrintPath(lab);
        }
    }
}