namespace DecimalToHex
{
    using System;
    using System.Collections.Generic;

    public class DecimalToHex
    {
        public static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            Stack<long> result = new Stack<long>();

            while (number > 0)
            {
                long currentNumber = number % 16;
                result.Push(currentNumber);
                number /= 16;
            }

            string output = string.Empty;
            while (result.Count > 0)
            {
                if (result.Peek() > 9)
                {
                    switch (result.Peek())
                    {
                        case 10:
                            output += "A";
                            break;
                        case 11:
                            output += "B";
                            break;
                        case 12:
                            output += "C";
                            break;
                        case 13:
                            output += "D";
                            break;
                        case 14:
                            output += "E";
                            break;
                        case 15:
                            output += "F";
                            break;
                    }

                    result.Pop();
                }
                else
                {
                    output += result.Pop();
                }
            }

            Console.WriteLine(output);
        }
    }
}
