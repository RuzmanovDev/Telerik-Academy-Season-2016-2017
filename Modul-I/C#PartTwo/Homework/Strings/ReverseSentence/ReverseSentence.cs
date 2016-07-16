namespace ReverseSentence
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class ReverseSentence
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>();
            StringBuilder result = new StringBuilder();

            foreach (var word in text)
            {
                stack.Push(word);
            }

            while (stack.Count != 0)
            {
                string word = stack.Pop();
                result.Append(word + " ");
            }

            Console.WriteLine(result.ToString());
        }
    }
}