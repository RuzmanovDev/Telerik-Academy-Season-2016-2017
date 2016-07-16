namespace MasterHerbalist
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class MasterHerbalist
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int dailyExpanses = int.Parse(Console.ReadLine());
            List<int> totalMoneyPerDay = new List<int>();
            int days = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "Season")
                {
                    break;
                }

                int hours = int.Parse(input[0]);
                string path = input[1];
                int price = int.Parse(input[2]);
                days++;

                int herbsGathered = 0;

                do
                {
                    for (int i = 0; i < path.Length; i++)
                    {
                        if (path[i] == 'H')
                        {
                            herbsGathered++;
                        }

                        hours--;
                        if (hours == 0)
                        {
                            break;
                        }
                    }
                }
                while (hours > 0);

                int moneyGained = herbsGathered * price;
                totalMoneyPerDay.Add(moneyGained);
            }

            long totalMoney = totalMoneyPerDay.Sum();
            double average = (double)totalMoney / days;

            if (average >= dailyExpanses)
            {
                Console.WriteLine("Times are good. Extra money per day: {0:F2}.", average - dailyExpanses);
            }
            else
            {
                Console.WriteLine("We are in the red. Money needed: {0}.", (int)((dailyExpanses * days) - totalMoney));
            }
        }
    }
}
