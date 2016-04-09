using System;


class Carpets
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        int topDots = input / 2 - 1;
        int currentRol = 2;
        Console.Write(new string('.', topDots));
        Console.Write('/');
        Console.Write('\\');
        Console.WriteLine(new string('.', topDots));
        topDots--;
        int innerLeft = 2;
        int innerRight = 2;
        for (int i = 0; i < input / 2 - 1; i++)
        {
            Console.Write(new string('.', topDots));
            for (int j = 0; j < innerLeft; j++)
            {
                if (j % 2 == 0)
                {
                    Console.Write('/');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            if (i % 2 == 0)
            {
                for (int k = 0; k < innerRight; k++)
                {
                    if (k % 2 == 0)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('\\');
                    }
                }
            }
            else
            {
                for (int k = 0; k < innerRight; k++)
                {
                    if (k % 2 == 0)
                    {
                        Console.Write('\\');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
            Console.WriteLine(new string('.', topDots));
            topDots--;
            innerLeft++;
            innerRight++;
            currentRol++;
        }

        //bottom
        topDots = 0;
        innerRight--;
        innerLeft--;


        for (int i = 0; i < input / 2 - 1; i++)
        {
            Console.Write(new string('.', topDots));
            for (int j = 0; j < innerLeft; j++)
            {
                if (j % 2 == 0)
                {
                    Console.Write('\\');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            if (currentRol % 2 == 0)
            {
                for (int k = 0; k < innerRight; k++)
                {
                    if (k % 2 == 0)
                    {
                        Console.Write('/');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
            else
            {
                for (int k = 0; k < innerRight; k++)
                {
                    if (k % 2 == 0)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('/');
                    }
                }
            }
            Console.WriteLine(new string('.', topDots));
            topDots++;
            innerLeft--;
            innerRight--;
            currentRol++;
        }


        Console.Write(new string('.', topDots));
        Console.Write('\\');
        Console.Write('/');
        Console.WriteLine(new string('.', topDots));
    }
}

