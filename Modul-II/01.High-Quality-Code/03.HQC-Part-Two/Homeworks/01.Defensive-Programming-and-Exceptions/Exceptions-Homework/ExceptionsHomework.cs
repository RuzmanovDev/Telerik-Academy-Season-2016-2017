using System;
using System.Collections.Generic;

using Exceptions_Homework.Helpers;

namespace Exceptions_Homework
{
    public class ExceptionsHomework
    {
        public static void Main()
        {
            var substr = ArrayExtensions.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = ArrayExtensions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = ArrayExtensions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = ArrayExtensions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(StringExtensions.ExtractEnding("I love C#", 2));
            Console.WriteLine(StringExtensions.ExtractEnding("Nakov", 4));
            Console.WriteLine(StringExtensions.ExtractEnding("beer", 4));

            // Console.WriteLine(StringExtensions.ExtractEnding("Hi", 100));
            bool isPrime = NumberExtensions.CheckPrime(23);
            if (isPrime)
            {
                Console.WriteLine("23 is prime.");
            }
            else
            {
                Console.WriteLine("23 is not prime");
            }

            bool checkIfPrime = NumberExtensions.CheckPrime(33);
            if (checkIfPrime)
            {
                Console.WriteLine("33 is prime.");
            }
            else
            {
                Console.WriteLine("33 is not prime");
            }

            List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}