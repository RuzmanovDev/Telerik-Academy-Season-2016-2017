namespace Printing
{
    using System;
    using System.Globalization;
    using System.Threading;

    class Printing
    {
        public static object CurrentCulture { get; private set; }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;

            // read input

            int numberOfStudents = int.Parse(Console.ReadLine());
            int sheetsPerStudent = int.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());
            int realm = 500;

            //logic

            decimal result = ((numberOfStudents * sheetsPerStudent) / (decimal)realm) * price;

            // print result 
            Console.WriteLine("{0:F2}", result);
        }
    }
}
