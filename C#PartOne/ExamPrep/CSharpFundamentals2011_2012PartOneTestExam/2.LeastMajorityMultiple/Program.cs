using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[5];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int maxCounter = 0;
        int answer = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 1; j < 101; j++)
            {
                int counter = 0;
                int majorityMultiple = numbers[i] * j;
                for (int z = 0; z < numbers.Length; z++)
                {
                    if (majorityMultiple % numbers[z] == 0)
                    {
                        counter++;
                    }
                    if (counter >=3)
                    {
                        
                        answer = majorityMultiple;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(answer);

    }
}

