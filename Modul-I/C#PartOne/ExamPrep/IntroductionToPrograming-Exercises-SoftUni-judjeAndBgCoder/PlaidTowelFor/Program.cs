using System;

namespace PlaidTowelFor
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char bgSymbol = char.Parse(Console.ReadLine());
            char rhSymbol = char.Parse(Console.ReadLine());

            int width = n * 4 + 1;
            int height = width;

            for (int r = 0; r < width; r++)
            {
                for (int c = 0; c < height; c++)
                {
                    if (r + c == n)
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r - c == n)
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r - c == -n)
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r - c == width - n - 1) // 
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r + c == width - n - 1)
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r + c == 7 * n)
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r + c == width - n - 1)
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r + c == width + n - 1)
                    {
                        Console.Write(rhSymbol);
                    }
                    else if (r - c == -n * 3) // 
                    {
                        Console.Write(rhSymbol);
                    }
                    else
                    {
                        Console.Write(bgSymbol);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}