namespace FindBits
{
    using System;

    class FindBits
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string pattern = Convert.ToString(input, 2).PadLeft(5, '0');
            int bitsCount = 0;

            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                string currentNumber = Convert.ToString(long.Parse(Console.ReadLine()), 2).PadLeft(29, '0');
                for (int index = 0; index < currentNumber.Length - 4; index++)
                {
                    int hasPattern = 0;
                    string checkingPattern = currentNumber.Substring(index, 5);
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        if (pattern[j] == checkingPattern[j])
                        {
                            hasPattern++;
                        }
                        else
                        {
                            hasPattern = 0;
                        }

                        if (hasPattern == 5)
                        {
                            bitsCount++;
                        }
                    }
                }
            }

            Console.WriteLine(bitsCount);
        }
    }
}
