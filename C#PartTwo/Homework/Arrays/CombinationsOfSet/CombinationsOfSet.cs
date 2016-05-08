namespace CombinationsOfSet
{
    using System;

    class Program
    {

        static int N = int.Parse(Console.ReadLine());
        static int K = int.Parse(Console.ReadLine());

        //generates variations
        static void Combinations(int[] array, int index, int currentNumber)
        {
            if (index == array.Length)
            {
                PrintArray(array);
            }
            else
            {
                for (int i = currentNumber; i <= N; i++)
                {
                    array[index] = i;
                    Combinations(array, index + 1, i + 1);
                }
            }
        }

        //prints array
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            int[] array = new int[K];
            Combinations(array, 0, 1);
        }
    }
}
