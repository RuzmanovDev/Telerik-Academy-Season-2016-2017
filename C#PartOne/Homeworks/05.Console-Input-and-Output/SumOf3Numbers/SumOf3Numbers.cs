namespace SumOf3Numbers
{
    using System;

    public class SumOf3Numbers
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int sum = a + b + c;

            Console.WriteLine(sum);
        }
    }
}
