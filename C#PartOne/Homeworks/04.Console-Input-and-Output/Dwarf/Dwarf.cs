namespace Dwarf
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    class Dwarf
    {
        public struct Figure
        {
            public Figure(int x, int y, char c, ConsoleColor color) : this()
            {
                this.x = x;
                this.y = y;
                this.c = c;
                this.color = color;
            }

            public int x;
            public int y;
            public char c;
            public ConsoleColor color;

        }

        public static void DrawOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        public static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 50;
            int playfieldWidth = 49;
            Figure dwarf = new Figure(25, Console.WindowHeight - 1, 'O', ConsoleColor.Red);
            Random randomGenerator = new Random();
            List<Figure> objects = new List<Figure>();
            while (true)
            {
                bool hitted = false;
                {
                    int chance = randomGenerator.Next(0, 100);
                    if (chance < 10)
                    {
                        var newObject = new Figure();
                        newObject = new Figure();
                        newObject.color = ConsoleColor.Cyan;
                        newObject.c = '-';
                        newObject.x = randomGenerator.Next(0, playfieldWidth);
                        newObject.y = 0;
                        objects.Add(newObject);
                    }
                    else if (chance < 20)
                    {
                        var newObject = new Figure();
                        newObject = new Figure();
                        newObject.color = ConsoleColor.Cyan;
                        newObject.c = '*';
                        newObject.x = randomGenerator.Next(0, playfieldWidth);
                        newObject.y = 0;
                        objects.Add(newObject);
                    }
                    
                }

                while (Console.KeyAvailable)
                {
                  
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.x - 1 >= 0)
                        {
                            dwarf.x = dwarf.x - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.x + 1 < playfieldWidth)
                        {
                            dwarf.x = dwarf.x + 1;
                        }
                    }

                    Console.Clear();
                    if (hitted)
                    {
                       
                        DrawOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
                    }
                    else
                    {
                        DrawOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
                    }
                }
                Thread.Sleep(500);
           
            }
           

        }
    }
}
