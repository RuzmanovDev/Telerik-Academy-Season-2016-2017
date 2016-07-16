using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slides
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] whd = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int width = whd[0];
            int height = whd[1];
            int depth = whd[2];
            string[,,] cube = new string[width, height, depth];

            for (int h = 0; h < width; h++)
            {
                string[] line = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                for (int d = 0; d < height; d++)
                {
                    string[] content = line[d].Split(new char[] { '(', ')' },StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < depth; w++)
                    {
                        cube[w, h, d] = content[w];
                    }
                }
            }


          

        }
    }
}
