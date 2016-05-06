namespace SelectionSort
{
    using System;

    class SelectionSort
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = minIndex + 1; j < numbers.Length; j++)
                {
                    if (numbers[minIndex] > numbers[j])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[minIndex];
                    numbers[minIndex] = temp;
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
