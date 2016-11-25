using System;
using System.Collections.Generic;

namespace ReversePolish
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentElement = input[i];
                int value;
                if (int.TryParse(currentElement, out value))
                {
                    stack.Push(value);
                }
                else
                {
                    int secondValue = stack.Pop();
                    int firstValue = stack.Pop();
                    int result = 0;

                    if (currentElement == "+")
                    {
                        result = firstValue + secondValue;
                    }
                    else if (currentElement == "-")
                    {
                        result = firstValue - secondValue;
                    }
                    else if (currentElement == "*")
                    {
                        result = firstValue * secondValue;
                    }
                    else if (currentElement == "/")
                    {
                        result = firstValue / secondValue;
                    }
                    else if (currentElement == "&")
                    {
                        result = firstValue & secondValue;
                    }
                    else if (currentElement == "|")
                    {
                        result = firstValue | secondValue;
                    }
                    else if (currentElement == "^")
                    {
                        result = firstValue ^ secondValue;
                    }

                    stack.Push(result);
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
