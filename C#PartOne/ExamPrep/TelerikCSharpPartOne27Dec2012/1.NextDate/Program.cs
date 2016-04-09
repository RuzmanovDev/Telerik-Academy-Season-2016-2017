namespace _1.NextDate
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
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
