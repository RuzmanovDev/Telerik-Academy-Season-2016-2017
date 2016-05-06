namespace FindSumInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindSumInArray
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int givenSum = int.Parse(Console.ReadLine());
            int sum = 0;
            int endIndex = 0;
            int startIndex = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                sum = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    sum += numbers[j];
                    if (sum == givenSum)
                    {
                        endIndex = j;
                        startIndex = i;
                    }
                }
            }

            List<int> result = new List<int>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                result.Add(numbers[i]);
            }

            Console.WriteLine("{" + string.Join(", ", result) + "}");
        }
    }
}
