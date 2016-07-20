namespace SubstractingPolinomials
{
    using System;
    using System.Linq;

    public class SubstractingPolinomials
    {
        public static void Main(string[] args)
        {
            string n = Console.ReadLine();

            int[] firstNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] secondNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < secondNumbers.Length; i++)
            {
                int result = 0;
                if ((firstNumbers[i] < 0 && 0 < secondNumbers[i])
                    || (firstNumbers[i] > 0 && 0 > secondNumbers[i]))
                {
                    result = firstNumbers[i] + secondNumbers[i];
                }
                else
                {
                    result = firstNumbers[i] - secondNumbers[i];
                }

                Console.Write("{0} ", result);
            }

            Console.WriteLine();
        }
    }
}
