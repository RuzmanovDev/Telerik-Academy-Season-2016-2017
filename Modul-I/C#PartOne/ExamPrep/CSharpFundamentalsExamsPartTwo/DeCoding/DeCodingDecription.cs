namespace DeCoding
{
    using System;

    public class DeCodingDecription
    {
        public static void Main(string[] args)
        {
            int salt = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                long value = 0;
                double result = 0;

                if (currentChar == '@')
                {
                    break;
                }
                else if (char.IsLetter(currentChar))
                {
                    value = (currentChar * salt) + 1000;
                }
                else if (char.IsDigit(currentChar))
                {
                    value = (currentChar + salt) + 500;
                }
                else
                {
                    value = currentChar - salt;
                }

                if (i % 2 == 0)
                {
                    result = (double)value / 100;
                    Console.WriteLine("{0:F2}", result);
                }
                else
                {
                    result = value * 100;
                    Console.WriteLine("{0}", result);
                }
            }
        }
    }
}
