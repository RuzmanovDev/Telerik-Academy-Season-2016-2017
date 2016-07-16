namespace FormatNumber
{
    using System;

    class FormatNumber
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine("{0:x}",number);
            Console.WriteLine("{0:F2}", number);
            Console.WriteLine("{0:p}", number);
            Console.WriteLine(number.ToString("G2"));

        }
    }
}