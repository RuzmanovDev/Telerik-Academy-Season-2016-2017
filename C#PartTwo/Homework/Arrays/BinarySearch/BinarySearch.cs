namespace BinarySearch
{
    using System;

    class BinarySearch
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int seekedNumber = int.Parse(Console.ReadLine());

            int startIndex = 0;
            int endIndex = numbers.Length - 1;
            int seekedIndex = -1;
            while (startIndex <= endIndex)
            {
                int middle = (startIndex + endIndex) / 2;

                if (numbers[middle] > seekedNumber)
                {
                    endIndex = middle - 1;
                }
                else if (numbers[middle] < seekedNumber)
                {
                    startIndex = middle + 1;
                }
                else
                {
                    seekedIndex = middle;
                    break;
                }
            }

            Console.WriteLine(seekedIndex);
        }
    }
}
