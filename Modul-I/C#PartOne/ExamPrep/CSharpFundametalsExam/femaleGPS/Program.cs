using System;


class Program
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int height = 2 * n;
        int top = n - 1;
        int topDots = n + 1;
        int drawingArea = 3 * n + 1;
        int forCounter = n - 2;
        int row = n + 1;
        int rowSecond = n - 1;
        int rowThird = n - 1;

        Console.Write(new string('.', topDots));
        Console.Write(new string('*', top));
        Console.WriteLine(new string('.', topDots));

        for (int i = 0; i <= forCounter && rowSecond > 0; i++)
        {
            Console.Write(new string('.', rowSecond));
            rowSecond -= 2; ;
            Console.Write("*");
            Console.Write(new string('.', row));
            row += 4;
            Console.Write("*");
            Console.WriteLine(new string('.', rowThird));
            rowThird -= 2;
            for (int j = 0; j < n-5; j++)
            {
                if (n > 4)
                {
                    
                    Console.Write(".");
                    Console.Write("*");
                    Console.Write(new string('.', drawingArea - 4));
                    Console.Write("*");
                    Console.Write(".");
                }
            }

        }



    }

}







