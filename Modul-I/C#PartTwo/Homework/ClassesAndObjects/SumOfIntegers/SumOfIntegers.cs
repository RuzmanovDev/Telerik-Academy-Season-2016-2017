namespace SumOfIntegers
{
    using System;
    using System.Linq;

    class SumOfIntegers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            long sum = numbers.Sum();

            Console.WriteLine(sum);
        }
    }
}
