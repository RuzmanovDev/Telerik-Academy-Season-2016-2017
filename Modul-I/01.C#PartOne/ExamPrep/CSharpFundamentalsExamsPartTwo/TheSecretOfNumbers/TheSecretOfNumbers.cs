namespace TheSecretOfNumbers
{
    using System;
    using System.Numerics;
    public class TheSecretOfNumbers
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            BigInteger number = BigInteger.Parse(input);
            if (number < 0)
            {
                number = -number;
            }
            input = number.ToString();

            BigInteger specialSum = 0;
            int position = 1;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (position % 2 == 0)
                {
                    specialSum += (BigInteger)Math.Pow(input[i] - '0', 2) * position;
                }
                else
                {
                    specialSum += (input[i] - '0') * (BigInteger)Math.Pow(position, 2);
                }
                position++;
            }

            string specialSumStr = specialSum.ToString();
            BigInteger lengthOfTheSecretAlphaSequence = specialSum % 10;
            BigInteger firstLetter = (specialSum % 26) + 1;

            if (lengthOfTheSecretAlphaSequence == 0)
            {
                Console.WriteLine(specialSum);
                Console.WriteLine("{0} has no secret alpha-sequence", input);
            }
            else
            {
                BigInteger nextChar = 'A' + firstLetter - 1;
                Console.WriteLine(specialSum);
                for (int i = 0; i < lengthOfTheSecretAlphaSequence; i++)
                {
                    Console.Write((char)nextChar);
                    nextChar++;
                    if (nextChar > 'Z')
                    {
                        nextChar = 'A';
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
