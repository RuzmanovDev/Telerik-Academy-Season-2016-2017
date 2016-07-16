namespace _9GagNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class NineGagNumbers
    {
        const int BASE = 9;
        static void Main(string[] args)
        {
            string[] digits = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
            var digit = new StringBuilder();
            var splittedNumber = new List<string>();

            string input = Console.ReadLine();
            ulong result = 0;
            //TODO: logic
            // bool found difit => add it to list else continue cycling ==== for + while??

            for (int i = 0; i < input.Length; i++)
            {
                bool foundDigit = false;
                while (!foundDigit && i < input.Length)
                {
                    digit.Append(input[i]);
                    string currentDigit = digit.ToString();
                    if (digits.Contains(currentDigit))
                    {
                        splittedNumber.Add(currentDigit);
                        foundDigit = true;
                        digit.Clear();
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            for (int i = 0; i < splittedNumber.Count; i++)
            {
                result *= 9;
                int valueOfDigit = Array.IndexOf(digits, splittedNumber[i]);
                result += (ulong)valueOfDigit;
            }

            Console.WriteLine(result);

            // Console.WriteLine(string.Join(" ", splittedNumber));
        }
    }
}