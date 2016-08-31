using System;

public class Task2
{
    public static void Main(string[] args)
    {
        int bussesCount = int.Parse(Console.ReadLine());

        int[] busses = new int[bussesCount];

        for (int i = 0; i < busses.Length; i++)
        {
            busses[i] = int.Parse(Console.ReadLine());
        }

        int groupsCount = 1;

        for (int i = 1; i < busses.Length; i++)
        {
            if (busses[i] > busses[i - 1])
            {
                busses[i] = busses[i - 1];
            }
            else if (busses[i] == busses[i - 1])
            {
                groupsCount++;
                continue;
            }
            else if (busses[i] < busses[i - 1])
            {
                groupsCount++;
            }
        }

        Console.WriteLine(groupsCount);
    }
}
