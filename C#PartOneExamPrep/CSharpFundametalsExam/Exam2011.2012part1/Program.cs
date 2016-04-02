using System;
class Program
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int bottom = 2 * n;
        int height = 2 * n + 1;
        int counter = n - 1;
        int dots = n - 1;
        Console.Write(new string('.',n));
        Console.WriteLine(new string('*', n));

        for (int i = 0; i < counter; i++)
        {
            Console.Write(new string('.', dots));
            dots--;
            Console.Write("*");
            Console.Write(new string('.', n - 1));
            n++;
            Console.WriteLine("*");


        }

        Console.WriteLine(new string('*',bottom));



    }
}

