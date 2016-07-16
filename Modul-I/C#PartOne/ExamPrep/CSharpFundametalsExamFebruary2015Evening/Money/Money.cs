namespace Money
{
    using System;
    using System.Globalization;
    using System.Threading;
    class Money
    {
        static void Main(string[] args)
        {
            
           
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int numberOfStundets = int.Parse(Console.ReadLine());
            int numberOfPapersPerStudent = int.Parse(Console.ReadLine());

            decimal price = decimal.Parse(Console.ReadLine());

            int totalPapers = numberOfStundets * numberOfPapersPerStudent;

            decimal result = (totalPapers / 400m)*price;

            Console.WriteLine("{0:F3}", result);
        }
    }
}