namespace DurankolakNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    class DurankolakNumbers
    {
        static void Main(string[] args)
        {
            char smallLetter = 'a';
            char capitalLetter = 'A';

            string[] digits = new string[168];
            for (int i = 0; i < 26; i++)
            {
                digits[i] = capitalLetter.ToString();
                capitalLetter++;
                capitalLetter = capitalLetter > 'Z' ? 'A' : capitalLetter;

            }
            for (int i = 26; i < digits.Length; i++)
            {
                if (i >= 52)
                {
                    smallLetter = 'b';
                }
                if (i >= 78)
                {
                    smallLetter = 'c';
                }
                if (i >= 104)
                {
                    smallLetter = 'd';
                }
                if (i >= 130)
                {
                    smallLetter = 'd';
                }
                if (i >= 156)
                {
                    smallLetter = 'f';
                }
                string currentDigit = smallLetter.ToString() + capitalLetter.ToString();
                capitalLetter++;
                capitalLetter = capitalLetter > 'Z' ? 'A' : capitalLetter;

                digits[i] = currentDigit;
            }

            string input = Console.ReadLine();
            BigInteger result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string currentDigit = string.Empty;
                if (char.IsUpper(input[i]))
                {
                    currentDigit = input[i].ToString();
                }
                else
                {
                    currentDigit = input.Substring(i, 2);
                    i += 1;
                }
                BigInteger value = (uint)Array.IndexOf(digits, currentDigit);
                result *= 168;
                result += value;
            }

            Console.WriteLine(result);
        }
    }
}
