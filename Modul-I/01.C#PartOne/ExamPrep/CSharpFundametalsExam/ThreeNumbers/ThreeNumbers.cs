using System;


namespace ThreeNumbers
{
    class ThreeNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double sum = a + b + c;
            double result = sum / 3;
            Console.WriteLine(Math.Max(a, Math.Max(b, c)));
            Console.WriteLine(Math.Min(a, Math.Min(b, c)));

            Console.WriteLine("{0:F2}", result);
        }

    }
}
