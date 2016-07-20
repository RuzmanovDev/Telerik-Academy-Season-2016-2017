namespace BinarySearch
{
    using System;
    using System.Linq;

    class BinarySearch
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());

            Array.Sort(numbers);

            int seekedNumberIndex = Array.BinarySearch(numbers, k) - 1;

            if (seekedNumberIndex < 0)
            {
                seekedNumberIndex++;
            }

            Console.WriteLine("The seeked number is {0}", numbers[seekedNumberIndex]);
        }
    }
}
