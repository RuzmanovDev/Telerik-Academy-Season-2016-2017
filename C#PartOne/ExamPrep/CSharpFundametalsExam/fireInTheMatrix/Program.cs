using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int topDots = n / 2 - 2;
        int dots = 2;
        int bottomDOts = 1;
        int dotsBottom = n - 4;
        char c = (char)92;
        char d = (char)47;
        int finalDots = 1;
        int slashesh = n / 2 - 1;

        Console.Write(new string('.', n / 2 - 1));
        Console.Write(new string('#', 2));
        Console.WriteLine(new string('.', n / 2 - 1));

        for (int i = 0; i < n / 2 - 2; i++)
        {
            Console.Write(new string('.', topDots));
            topDots--;
            Console.Write("#");
            Console.Write(new string('.', dots));
            dots += 2;
            Console.Write("#");
            Console.WriteLine(new string('.', topDots + 1));
        }
        Console.Write("#");
        Console.Write(new string('.', n - 2));
        Console.WriteLine("#");
        Console.Write("#");
        Console.Write(new string('.', n - 2));
        Console.WriteLine("#");


        for (int i = 0; i < (n - 4) / 4; i++)
        {
            Console.Write(new string('.', bottomDOts));
            bottomDOts++;
            Console.Write("#");
            Console.Write(new string('.', dotsBottom));
            dotsBottom -= 2;
            Console.Write("#");
            Console.WriteLine(new string('.', bottomDOts - 1));
        }

        Console.WriteLine(new string('-', n));


        Console.Write(new string(c, n / 2));
        Console.WriteLine(new string(d, n / 2));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', finalDots));
            finalDots++;

            Console.Write(new string(c, slashesh));
            slashesh--;

            Console.Write(new string(d, slashesh+1));

            Console.WriteLine(new string('.', finalDots-1));
            


        }

    }

}

