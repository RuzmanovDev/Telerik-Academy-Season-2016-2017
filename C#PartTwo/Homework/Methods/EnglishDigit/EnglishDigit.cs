namespace EnglishDigit
{
    using System;

    class EnglishDigit
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string lastDigit = GetLastDigitInEnglish(number);

            Console.WriteLine(lastDigit);
        }

        private static string GetLastDigitInEnglish(int number)
        {
            string[] digitInEnglish = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int lastDigit = number % 10;
            string lastDigitAsEnglish = digitInEnglish[lastDigit];

            return lastDigitAsEnglish;
        }
    }
}
