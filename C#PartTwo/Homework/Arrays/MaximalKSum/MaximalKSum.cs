namespace MaximalKSum
{
    using System;

    class MaximalKSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);
            int maxSum = 0;
            for (int i = numbers.Length - 1; i >= numbers.Length - k; i--)
            {
                maxSum += numbers[i];
            }

            Console.WriteLine(maxSum);
        }
    }
}
