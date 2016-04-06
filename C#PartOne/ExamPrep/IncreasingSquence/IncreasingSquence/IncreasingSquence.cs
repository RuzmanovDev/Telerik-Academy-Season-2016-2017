using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingSquence
{
    class IncreasingSquence
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<bool> answers = new List<bool>();
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = Array.ConvertAll(inputNumbers, n => int.Parse(n));

                answers.Add(IsIncreasing(numbers));

            }
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        private static bool IsIncreasing(int[] numbers)
        {
            // bool isIncreasing = false;
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                int currentSeq = Math.Abs(Math.Abs(numbers[i] - numbers[i + 1]) - Math.Abs(numbers[i + 1] - numbers[i + 2]));
                if (currentSeq > 1 || Math.Abs(numbers[i] - numbers[i + 1]) > Math.Abs(numbers[i + 1] - numbers[i + 2]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
