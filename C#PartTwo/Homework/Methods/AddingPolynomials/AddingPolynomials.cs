namespace AddingPolynomials
{
    using System;
    using System.Linq;

    public class AddingPolynomials
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
                Console.Write("{0} ", firstNumbers[i] + secondNumbers[i]);
            }

            Console.WriteLine();
        }
    }
}
