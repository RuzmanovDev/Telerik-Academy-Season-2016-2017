using System;

class Task2
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] busses = new int[n];

        for (int i = 0; i < busses.Length; i++)
        {
            busses[i] = int.Parse(Console.ReadLine());
        }

        int groups = 1;

        for (int i = 1; i < busses.Length; i++)
        {
            if (busses[i] > busses[i - 1])
            {
                busses[i] = busses[i - 1];
            }
            else if (busses[i] == busses[i - 1])
            {
                groups++;
                continue;
            }
            else if (busses[i] < busses[i - 1])
            {
                groups++;
            }

        }

        Console.WriteLine(groups);
    }
}

