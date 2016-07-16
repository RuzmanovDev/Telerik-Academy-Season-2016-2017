using System;

class Task1
{
    static void Main(string[] args)
    {
        int b = int.Parse(Console.ReadLine());
        long f = long.Parse(Console.ReadLine());

        double average = f / (double)b;
        double result = 0;

        if (b == 0 || f == 0)
        {
            Console.WriteLine(0);
            return;
        }

        if (b % 2 == 0)
        {
            result = 123123123123 * average;
        }
        else
        {
            result = average / 317;
        }

        Console.WriteLine("{0:F4}", result);
    }
}
