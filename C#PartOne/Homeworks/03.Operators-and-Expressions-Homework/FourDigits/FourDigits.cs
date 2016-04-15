namespace FourDigits
{
    using System;

    class FourDigits
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;
            string reversedNumber = "";

            int number = input;
            while (number!=0)
            {
                int cuurentDigit = number % 10;
                sumOfDigits += cuurentDigit;
                reversedNumber += cuurentDigit;
                number /= 10;
            }
            number = input;
            int lastDigit = number % 10;
            number /= 10;
            string lastDigitAsFirst = lastDigit.ToString() + number.ToString();
            int thirdDigit = number % 10;
            number /= 10;
            int secondDigit = number % 10;
            number /= 10;
            string exchangeSecondAndThirdDigit = number.ToString() + thirdDigit.ToString() + secondDigit.ToString() + lastDigit.ToString();

            Console.WriteLine(sumOfDigits);
            Console.WriteLine(reversedNumber);
            Console.WriteLine(lastDigitAsFirst);
            Console.WriteLine(exchangeSecondAndThirdDigit);
        }
    }
}
