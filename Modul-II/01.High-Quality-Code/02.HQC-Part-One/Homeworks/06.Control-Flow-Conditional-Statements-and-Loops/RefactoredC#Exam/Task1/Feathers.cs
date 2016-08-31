using System;

public class Task1
{
   public static void Main(string[] args)
    {
        const long MagicNumberForEvenBirds = 123123123123;
        const int MagicNumberForOddBirds = 317;

        int birdsCount = int.Parse(Console.ReadLine());
        long feathersCounts = long.Parse(Console.ReadLine());

        double average = feathersCounts / (double)birdsCount;
        double result = 0;

        if (birdsCount == 0 || feathersCounts == 0)
        {
            Console.WriteLine(0);
            return;
        }

        if (birdsCount % 2 == 0)
        {
            result = MagicNumberForEvenBirds * average;
        }
        else
        {
            result = average / MagicNumberForOddBirds;
        }

        Console.WriteLine("{0:F4}", result);
    }
}
