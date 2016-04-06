using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBitOne
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] matrix = new char[8, 8];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sb.Append(Convert.ToString(number, 2).PadLeft(8, '0'));
            }
            string bits = sb.ToString();
            int index = 0;
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    matrix[r, c] = bits[index];
                    index++;
                }
            }


            int[] startPosition = new int[2];

            startPosition[0] = 0; //rows
            startPosition[1] = 7; //cols
            int couner = 0;
            //move south
            while (true)
            {


                while (matrix[startPosition[0], startPosition[1]] == '0')
                {
                    couner++;
                    startPosition[0]++;
                    if (startPosition[0] > 7)
                    {
                        break;
                    }
                }
                startPosition[0]--;

                if ((startPosition[0] == 0 && startPosition[1] == 0) || matrix[startPosition[0], startPosition[1] - 1] == '1')
                {
                    break;
                }

                //move west
                while (matrix[startPosition[0], startPosition[1]] == '0')
                {
                    couner++;
                    startPosition[1]--;
                    if (startPosition[1] < 0)
                    {
                        break;
                    }
                }
                startPosition[1]++;
                if ((startPosition[0] == 0 && startPosition[1] == 0) || matrix[startPosition[0] - 1, startPosition[1]] == '1')
                {
                    break;
                }

                //move north
                while (matrix[startPosition[0], startPosition[1]] == '0')
                {
                    couner++;
                    startPosition[0]--;
                    if (startPosition[0] < 0)
                    {
                        break;
                    }
                }
                startPosition[0]++;



                //last 
                if ((startPosition[0] == 0 && startPosition[1] == 0) || matrix[startPosition[0], startPosition[1] - 1] == '1')
                {
                    break;
                }

                //move west
                while (matrix[startPosition[0], startPosition[1]] == '0')
                {
                    couner++;
                    startPosition[1]--;
                    if (startPosition[1] < 0)
                    {
                        break;
                    }
                }
                startPosition[1]++;
                if ((startPosition[0] == 0 && startPosition[1] == 0) || matrix[startPosition[0]+1, startPosition[1]] == '1')
                {
                    break;
                }

            }
            Console.WriteLine(couner);
        }
    }
}
