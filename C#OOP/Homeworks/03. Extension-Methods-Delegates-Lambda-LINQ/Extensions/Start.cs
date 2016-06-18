namespace Extensions
{
    using System;
    using System.Collections.Generic;

    public class Start
    {
        public static void Main(string[] args)
        {
            var nums = new List<double>() { 1.20, 2.22, 3.222, 4.2, 5.2 };

            var average = nums.Average();
            var sum = nums.Sum();
            var product = nums.Product();
            var min = nums.Min();
            var max = nums.Max();

            Console.WriteLine(average);
            Console.WriteLine(sum);
            Console.WriteLine(product);
            Console.WriteLine(min);
            Console.WriteLine(max);
        }
    }
}
