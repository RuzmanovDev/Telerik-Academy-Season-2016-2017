namespace Calculations
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Calculations
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            long min = numbers.Min();
            long max = numbers.Max();
            double average = numbers.Average();
            long sum = numbers.Sum();
            BigInteger prodcut = Product(numbers);

            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine("{0:F2}", average);
            Console.WriteLine(sum);
            Console.WriteLine(prodcut);
        }

        private static BigInteger Product(int[] numbers)
        {
            BigInteger product = 1;

            foreach (var num in numbers)
            {
                product *= num;
            }

            return product;
        }
    }
}
