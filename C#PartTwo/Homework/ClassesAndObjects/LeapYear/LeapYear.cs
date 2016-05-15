namespace LeapYear
{
    using System;

    class LeapYear
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());

            bool isLeapYear = DateTime.IsLeapYear(year);

            if (isLeapYear)
            {
                Console.WriteLine("Leap");
            }
            else
            {
                Console.WriteLine("Common");
            }
        }
    }
}
