using System;

class ForestRoad
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = 2 * width - 1;
        int asterixDraw = 0;

        for (int r = 0; r < height; r++)
        {
            for (int c = 0; c < width; c++)
            {
                if (asterixDraw == c)
                {
                    Console.Write("*");
                    
                }
                else
                {
                    Console.Write(".");
                }
            }
            
            if (asterixDraw>=width-1 || r>height/2-1)
            {
                asterixDraw--;
            }
            else
            {
                asterixDraw++;
            }
            Console.WriteLine();
        }

    }
}
