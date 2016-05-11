namespace ReverseNumber
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ReverseNumber
    {
        public static void Main(string[] args)
        {
            string number = Console.ReadLine();

            string reversedNumber = Reverse(number);
            Console.WriteLine(reversedNumber);
        }

        private static string Reverse(string number)
        {
            StringBuilder reversedNumber = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < number.Length; i++)
            {
                char currentChar = number[i];
                stack.Push(currentChar);
            }

            while (stack.Count != 0)
            {
                char poppedChar = stack.Pop();
                reversedNumber.Append(poppedChar);
            }

            return reversedNumber.ToString();
        }
    }
}
