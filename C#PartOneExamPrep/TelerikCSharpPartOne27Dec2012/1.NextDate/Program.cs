using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.NextDate
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());


            DateTime date = new DateTime(day, month, year);
            DateTime nextDate = date.AddDays(1);

            Console.WriteLine(nextDate.Day + "." + nextDate.Month + "." + nextDate.Year);


        }
    }
}
