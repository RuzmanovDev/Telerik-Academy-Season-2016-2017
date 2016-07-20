using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateForExam
{
    class LateForExam
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrrivalMinutes = int.Parse(Console.ReadLine());


            TimeSpan examTime = new TimeSpan(examHour, examMinutes, 0);
            TimeSpan arrivalTime = new TimeSpan(arrivalHour, arrrivalMinutes, 0);

            var difference = examTime - arrivalTime;


            if (difference.Hours == 0 && difference.Minutes <= 30 && difference.Minutes >= 0)
            {
                Console.WriteLine("On time");
                if (difference.Minutes > 0)
                {
                    Console.WriteLine("{0} minutes before the start", Math.Abs(difference.Minutes));
                }
            }
            else if (difference.Hours < 0 || difference.Minutes < 0)
            {
                Console.WriteLine("Late");

                if (difference.Hours < 0)
                {
                    Console.WriteLine("{0}:{1:00} hours after the start", Math.Abs(difference.Hours), Math.Abs(difference.Minutes));
                }
                else if (difference.Hours == 0)
                {
                    Console.WriteLine("{0} minutes after the start", Math.Abs(difference.Minutes));
                }
            }
            else
            {
                Console.WriteLine("Early");

                if (difference.Hours > 0)
                {
                    Console.WriteLine("{0}:{1:00} hours before the start", difference.Hours, difference.Minutes);
                }
                else if (difference.Hours == 0)
                {
                    Console.WriteLine("{0} minutes before the start", difference.Minutes);
                }
            }

        }
    }
}