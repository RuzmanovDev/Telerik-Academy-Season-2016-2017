namespace NightmareOnCodeStreet
{
    using System;

    class NightmareOnCodeStreet
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long oddDigitsCount = 0;
            long oddDidigtsSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0 && char.IsDigit(input[i]))
                {
                    oddDidigtsSum += input[i] - '0';
                    oddDigitsCount++;
                }
            }

            Console.Write(oddDigitsCount + " ");
            Console.WriteLine(oddDidigtsSum);
        }
    }
}
