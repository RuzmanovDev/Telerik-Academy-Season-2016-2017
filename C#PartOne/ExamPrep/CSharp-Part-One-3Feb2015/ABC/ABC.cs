namespace ABC
{
    using System;

    class ABC
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int biggest = Math.Max(Math.Max(a, b), c);
            int min = Math.Min(Math.Min(a, b), c);

            int sum = a + b + c;
            double aritmetical = sum / 3d;

            Console.WriteLine(biggest);
            Console.WriteLine(min);
            Console.WriteLine("{0:F3}", aritmetical);
        }
    }
}
