using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int startingDay = int.Parse(Console.ReadLine());
        int daysEating = int.Parse(Console.ReadLine());
        int melons = 0;
        int watermelons = 0;
        for (int i = 0; i < daysEating; i++)
        {
            switch (startingDay)
            {
                case 1:
                    watermelons++;
                    break;
                case 2:
                    melons += 2;
                    break;
                case 3:
                    watermelons++;
                    melons++;
                    break;
                case 4:
                    watermelons += 2;
                    break;
                case 5:
                    watermelons += 2;
                    melons += 2;
                    break;
                case 6:
                    watermelons++;
                    melons += 2;
                    break;
                case 7: break;



                default:
                    break;
            }
            startingDay++;
            if (startingDay>7)
            {
                startingDay = 1;
            }
        }


        if (watermelons > melons)
        {
            Console.WriteLine("{0} more watermelons", watermelons - melons);
        }
        else if (watermelons < melons)
        {
            Console.WriteLine("{0} more melons", melons - watermelons);
        }
        else
        {
            Console.WriteLine("Equal amount: {0}", melons);
        }

    }
}
