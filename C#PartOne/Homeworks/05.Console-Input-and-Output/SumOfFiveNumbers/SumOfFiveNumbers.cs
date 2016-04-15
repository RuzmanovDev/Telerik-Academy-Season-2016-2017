namespace SumOfFiveNumbers
{
    using System;

    public class SumOfFiveNumbers
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }

             Console.WriteLine(sum);
        }
    }
}
