namespace TheHorror
{
    using System;

    public class TheHorror
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long evenCount = 0;
            long evenSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0 && char.IsDigit(input[i]))
                {
                    evenCount++;
                    evenSum += input[i] - '0';
                }
            }

            Console.WriteLine("{0} {1}", evenCount, evenSum);
        }
    }
}
