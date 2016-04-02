using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        string[] cubeDimentions = Console.ReadLine().Split();
        int width = int.Parse(cubeDimentions[0]);
        int height = int.Parse(cubeDimentions[1]);
        int depth = int.Parse(cubeDimentions[2]);


        string[,,] cube = new string[width, height, depth];



        for (int h = 0; h < cube.GetLength(0); h++)
        {
            string[] lines = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < cube.GetLength(1); d++)
            {
                string[] content = lines[d].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < cube.GetLength(2); w++)
                {
                    cube[w, h, d] = content[w];
                }
            }
        }

    }
}

