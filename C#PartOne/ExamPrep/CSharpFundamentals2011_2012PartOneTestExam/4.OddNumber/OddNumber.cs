using System;
using System.Collections.Generic;

class OddNumber
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        long[] numbers = new long[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());

        }

        for (int i = 0; i < numbers.Length; i++)
        {
            int counter = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    counter++;
                }
            }
            if (counter % 2 != 0)
            {
                Console.WriteLine(numbers[i]);
                return;
            }
        }

    }
}

