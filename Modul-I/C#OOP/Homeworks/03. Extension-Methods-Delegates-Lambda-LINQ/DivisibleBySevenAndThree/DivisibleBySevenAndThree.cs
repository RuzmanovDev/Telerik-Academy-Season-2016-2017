// Problem 6. Divisible by 7 and 3
namespace DivisibleBySevenAndThree
{
    using System;
    using System.Linq;

    public class DivisibleBySevenAndThree
    {
        public static void Main(string[] args)
        {
            var nums = new[] { 2, 3, 1, 2, 14, 21, 33, 323, 123, 42 };

            // with LINQ
            var filtered = from num in nums
                           where num % 3 == 0 && num % 7 == 0
                           select num;

            Console.WriteLine(string.Join(", ", filtered));

            // wih extension methods
            var numsDivisibleBySevenAndThree = nums.Where(n => n % 7 == 0 && n % 3 == 0);
            Console.WriteLine(string.Join(", ", numsDivisibleBySevenAndThree));
        }
    }
}
