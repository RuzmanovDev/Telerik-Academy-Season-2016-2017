using System;
using System.Diagnostics;

namespace Compare_Advanced_Maths
{
    public class AdvancedMathTest
    {
        private const int CycleCount = 1000000;
        private const int NumberToDoOperationWith = 1;

        public static void Main(string[] args)
        {
            Console.WriteLine("Double");
            TestIngSimpleMath(2D);

            Console.WriteLine("Decimal");
            TestIngSimpleMath(2M);

            Console.WriteLine("Float");
            TestIngSimpleMath(2F);
        }

        private static void TestIngSimpleMath(dynamic number)
        {
            Console.WriteLine("Square root");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < CycleCount; i++)
                {
                    Math.Sqrt((double)number);
                }
            });

            Console.WriteLine("Natural Logarithm");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < CycleCount; i++)
                {
                    Math.Log((double)number);
                }
            });

            Console.WriteLine("Sinus");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < CycleCount; i++)
                {
                    Math.Sin((double)number);
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
