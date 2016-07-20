namespace SolveTasks
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class SolveTasks
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Menu();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Enter the number you want to reverse: ");
                string input = Console.ReadLine();
                string reversedNumber = Reverse(input);
                Console.WriteLine(reversedNumber);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the the sequence seperated by , or ' '!: ");
                Console.WriteLine("The average of the sequence is {0}", AverageOfSequence());
            }
            else if (choice == 3)
            {
                Console.WriteLine("a*x + b = 0");
                Console.Write("Enter a= ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Enter b= ");
                double b = double.Parse(Console.ReadLine());
                double result = LinearEquationRoot(a, b);
                Console.WriteLine("x= {0} ", result);
            }
            else
            {
                Console.WriteLine("Wrong command! Please try again!");
            }
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

        private static void Menu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1. Reverse the digit of a number.");
            Console.WriteLine("2. Calculate the average of a sequence of integers.");
            Console.WriteLine("3. Solve a linear equation  a * x + b = 0");
            Console.Write("Enter you choice: ");
        }

        private static double AverageOfSequence()
        {
            var seqence = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double sum = 0;

            foreach (var number in seqence)
            {
                sum += number;
            }

            double average = sum / seqence.Length;
            return average;
        }

        private static double LinearEquationRoot(double a, double b)
        {
            //a*x+b=0 -> x= - b /a
            double result = 0;
            try
            {
                result = -b / a;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("a must NOT be 0");
            }

            return result;
        }
    }
}