using System;
using System.Diagnostics;

namespace CompareSimpleMath
{
    public class SimpleMathTest
    {
        private const int CycleCount = 1000000;
        private const int NumberToDoOperationWith = 1;

        public static void Main(string[] args)
        {
            Console.WriteLine("Int");
            TestIngSimpleMath(2);

            Console.WriteLine("Long");
            TestIngSimpleMath(2F);

            Console.WriteLine("Double");
            TestIngSimpleMath(2D);

            Console.WriteLine("Decimal");
            TestIngSimpleMath(2M);

            Console.WriteLine("Float");
            TestIngSimpleMath(2F);
        }

        private static void TestIngSimpleMath(dynamic number)
        {
            Console.WriteLine("Addition");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < CycleCount; i++)
                {
                    number += NumberToDoOperationWith;
                }
            });

            Console.WriteLine("Substraction");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < CycleCount; i++)
                {
                    number -= NumberToDoOperationWith;
                }
            });

            Console.WriteLine("Multiplication");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < CycleCount; i++)
                {
                    number *= NumberToDoOperationWith;
                }
            });

            Console.WriteLine("Devision");
            DisplayExecutionTime(() =>
            {
                for (int i = 1; i < CycleCount; i++)
                {
                    number /= NumberToDoOperationWith;
                }
            });

            Console.WriteLine("Increment");
            DisplayExecutionTime(() =>
            {
                for (int i = 1; i < CycleCount; i++)
                {
                    number++;
                }
            });

            PrintSeperator();
        }

        private static void PrintSeperator()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
