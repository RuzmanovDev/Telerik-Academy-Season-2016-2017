using System;
using System.Collections.Generic;

class BinaryDigit
{
    static void Main(string[] args)
    {

        char binaryDigit = char.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        long[] numbers = new long[n];
        string[] binaryNumbers = new string[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        for (int i = 0; i < binaryNumbers.Length; i++)
        {
            binaryNumbers[i] = Convert.ToString(numbers[i], 2);
        }



        for (int i = 0; i < binaryNumbers.Length; i++)
        {
            long binaryDigitCounter = 0;
            string currentNumber = binaryNumbers[i];
            for (int j = 0; j < currentNumber.Length; j++)
            {
                if (currentNumber[j].Equals(binaryDigit))
                {
                    binaryDigitCounter++;
                }
            }
            Console.WriteLine(binaryDigitCounter);
        }

    }
}
