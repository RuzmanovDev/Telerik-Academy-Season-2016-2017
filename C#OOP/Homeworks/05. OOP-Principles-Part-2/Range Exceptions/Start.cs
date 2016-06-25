namespace Range_Exceptions
{
    using System;

    public class Start
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("If you eneter a number > 100 exception will be trown");
            int number = int.Parse(Console.ReadLine());

            try
            {
                if (number < 0 || number > 100)
                {
                    throw new InvalidRangeException<int>("Number is invalid!", 0, 100);
                }

                Console.WriteLine("Number correct!");
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("Enter date between 1.1.1980 and 31.12.2013 \n\r(format should be Year.Month.Day): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            try
            {
                if (date < new DateTime(1980, 1, 1) || date > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("Date is invalid!", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }

                Console.WriteLine("Date correct!");
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
