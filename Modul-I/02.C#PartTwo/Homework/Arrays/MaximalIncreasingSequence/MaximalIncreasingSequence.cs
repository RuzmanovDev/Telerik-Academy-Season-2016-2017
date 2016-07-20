namespace MaximalIncreasingSequence
{
    using System;

    class MaximalIncreasingSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int count = 1;
            int maxCount = 1;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] < numbers[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (count >= maxCount)
                {
                    maxCount = count;
                }
            }

            Console.WriteLine(maxCount);
        }
    }
}
