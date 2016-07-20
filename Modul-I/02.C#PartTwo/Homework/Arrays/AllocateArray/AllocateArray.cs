namespace AllocateArray
{
    using System;

    class AllocateArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i * 5;
            }

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
