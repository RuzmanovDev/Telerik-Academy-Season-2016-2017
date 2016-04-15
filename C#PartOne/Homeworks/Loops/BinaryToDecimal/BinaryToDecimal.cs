namespace BinaryToDecimal
{
    using System;

    public class BinaryToDecimal
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long result = 0;
            int power = input.Length - 1;
            for (int i = 0; i < input.Length; i++)
            {
                result += (input[i] - '0') * (long)Math.Pow(2, power);
                power--;
            }

            Console.WriteLine(result);
        }
    }
}
