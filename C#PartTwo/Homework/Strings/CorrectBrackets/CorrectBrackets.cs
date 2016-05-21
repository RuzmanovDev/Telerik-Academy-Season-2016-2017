namespace CorrectBrackets
{
    using System;
    using System.Collections.Generic;

    class CorrectBrackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();
            bool correct = true;
            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                if (currentSymbol == '(')
                {
                    brackets.Push(currentSymbol);
                }
                else if (currentSymbol == ')' && brackets.Count == 0)
                {
                    correct = false;
                    break;
                }
                else if (currentSymbol == ')')
                {
                    brackets.Pop();
                }
            }

            if (correct && brackets.Count != 0 && brackets.Peek() == '(')
            {
                correct = false;
            }

            if (!correct)
            {
                Console.WriteLine("Incorrect");
            }
            else
            {
                Console.WriteLine("Correct");
            }

        }
    }
}