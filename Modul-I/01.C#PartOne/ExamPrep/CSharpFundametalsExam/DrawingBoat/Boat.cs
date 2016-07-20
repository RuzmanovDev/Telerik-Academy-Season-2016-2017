using System;

class Boat
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int height = 6 + ((n - 3) / 2) * 3;
        int width = n * 2 + 1;

        int topDots = n - 2;
        int dots = 1;
        Console.Write(new string('.', n ));
        Console.Write("*");
        Console.WriteLine(new string('.', n));

        Console.Write(new string('.', n-1));
        Console.Write(new string('*', 3));
        Console.WriteLine(new string('.', n - 1));

        for (int i = 0; i < n - 2; i++)
        {
            Console.Write(new string('.', topDots));
            topDots--;
            Console.Write("*");
            
            Console.Write(new string('.', dots));
            dots++;

            Console.Write("*");
            Console.Write(new string('.', dots-1));
            Console.Write("*");

            Console.WriteLine(new string('.', topDots+1));
        }
        Console.WriteLine(new string('*',width));

        int bottomDots = 1;
        int bRows = n - 2;

        for (int i = 0; i < (n-1)/2; i++)
        {
            Console.Write(new string('.',bottomDots ));
            bottomDots++;
            Console.Write("*");
            Console.Write(new string('.', bRows));
            bRows--;
            Console.Write("*");
            Console.Write(new string('.', bRows+1));
            Console.Write("*");
            Console.WriteLine(new string('.', bottomDots-1));

        }

        Console.Write(new string('.',(width+1)/4));
        Console.Write(new string('*',n));
        Console.WriteLine(new string('.', (width + 1) / 4));
    }
}
