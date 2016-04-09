namespace Sheets
{
    using System;

    class Sheets
    {
        static void Main(string[] args)
        {
            int[] sheets = { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < sheets.Length; i++)
            {
                if (sheets[i] > number)
                {
                    Console.WriteLine("A{0}", i);
                }
                else
                {
                    number -= sheets[i];
                }
                
            }
        }
    }
}
