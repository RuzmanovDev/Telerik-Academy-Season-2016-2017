namespace GCD
{
    using System;
    using System.Linq;

    public class GCD
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            // Always sort array ascending
            Array.Sort(numbers);

            int a = Math.Abs(numbers[1]); // this is the greater number
            int b = Math.Abs(numbers[0]);

            // Euclidean algorithm https://en.wikipedia.org/wiki/Euclidean_algorithm#Implementations
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            Console.WriteLine(a);
        }

        public static int Gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return Gcd(b, a % b);
            }
        }
    }
}