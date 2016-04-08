namespace AstrologicalDigits
{
    using System;

    class AstrologicalDigits
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long sum = 0;

            while (true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(input[i].Equals('.') || input[i].Equals('-')))
                    {
                        sum += int.Parse(input[i].ToString());
                    }
                }
                if (sum < 10)
                {
                    break;
                }
                input = sum.ToString();
                sum = 0;
            }
            Console.WriteLine(sum);
        }
    }
}
