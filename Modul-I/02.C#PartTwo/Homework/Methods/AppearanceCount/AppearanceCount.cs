namespace AppearanceCount
{
    using System;
    using System.Linq;

    public class AppearanceCount
    {
        public static void Main(string[] args)
        {
            int arraySize = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int seekedNumber = int.Parse(Console.ReadLine());

            int occuRanceOfSeekedNumber = SeekedNumberCount(numbers, seekedNumber);

            Console.WriteLine(occuRanceOfSeekedNumber);
        }

        private static int SeekedNumberCount(int[] numbers, int seekedNumber)
        {
            int occurances = 0;
            foreach (var number in numbers)
            {
                if (number == seekedNumber)
                {
                    occurances++;
                }
            }

            return occurances;
        }
    }
}
