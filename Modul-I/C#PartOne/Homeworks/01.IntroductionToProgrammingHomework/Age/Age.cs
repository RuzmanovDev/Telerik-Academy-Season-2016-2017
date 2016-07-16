using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age
{
    class Age
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int month = int.Parse(input.Substring(0, 2));
            int date = int.Parse(input.Substring(3, 2));
            int year = int.Parse(input.Substring(6));



            if (month > DateTime.Now.Month || (date > DateTime.Now.Day && month > DateTime.Now.Month))
            {
                year++;
            }
            var birthDate = new DateTime(year, month, date);
            var age = DateTime.Now.Year - birthDate.Year;
            Console.WriteLine(age);
            Console.WriteLine(age + 10);

        }
    }
}
