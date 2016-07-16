using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingBasics_Exam30August2015
{
    class DailyCalorieIntake
    {
        static void Main(string[] args)
        {
            long weight = long.Parse(Console.ReadLine());
            long height = long.Parse(Console.ReadLine());
            long age = long.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long workoutsPerWeek = long.Parse(Console.ReadLine());
            

            double weightInKilograms = weight / 2.2d;
            double heightInCentimeters = height * 2.54d;


            double menBMR = 66.5d + (13.75d * weightInKilograms) + (5.003d * heightInCentimeters) - (6.755d * age);
            double womenBMR = 655 + (9.563d * weightInKilograms) + (1.850d * heightInCentimeters) - (4.676 * age);

            double dci;
            if (workoutsPerWeek == 0)
            {
                dci = 1.2d;
            }
            else if (workoutsPerWeek == 1 || workoutsPerWeek == 2 || workoutsPerWeek == 3)
            {
                dci = 1.375d;
            }
            else if (workoutsPerWeek == 4 || workoutsPerWeek == 5 || workoutsPerWeek == 6)
            {
                dci = 1.55d;
            }
            else if (workoutsPerWeek == 7 || workoutsPerWeek == 8 || workoutsPerWeek == 9)
            {
                dci = 1.725d;
            }
            else  
            {
                dci = 1.9d;
            }

            if (gender == 'm')
            {
                Console.WriteLine(Math.Floor(dci * menBMR));
            }
            else
            {
                Console.WriteLine(Math.Floor(dci * womenBMR));
            }






        }
    }
}
