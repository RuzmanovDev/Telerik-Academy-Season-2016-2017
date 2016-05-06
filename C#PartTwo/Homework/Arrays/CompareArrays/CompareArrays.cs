namespace CompareArrays
{
    using System;

    class CompareArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = ReadArray(n);
            int[] secondNumbers = ReadArray(n);

            bool isEqual = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != secondNumbers[i])
                {
                    isEqual = false;
                    break;
                }
            }

            if (isEqual)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
        }
        static int[] ReadArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }
    }
}
