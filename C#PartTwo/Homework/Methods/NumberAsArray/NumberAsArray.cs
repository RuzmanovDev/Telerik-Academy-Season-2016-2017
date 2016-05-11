namespace NumberAsArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NumberAsArray
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string inputForFirstArray = Console.ReadLine();
            string inpuForSecondArray = Console.ReadLine();

            int maxSize = Math.Max(sizes[0], sizes[1]); // +1 because when we add the last digit we may have transition         

            var firstArray = InitialiseIntarray(inputForFirstArray, maxSize);
            var secondArray = InitialiseIntarray(inpuForSecondArray, maxSize);


            var result = SumLists(firstArray, secondArray);

            foreach (var number in result)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        private static List<int> SumLists(List<int> firstArray, List<int> secondArray)
        {
            List<int> result = new List<int>();

            int transition = 0; //  9 + 1 = 0 transition = 1;
            for (int i = 0; i < firstArray.Count; i++)
            {
                int currentSum = firstArray[i] + secondArray[i] + transition;
                if (currentSum <= 9)
                {
                    result.Add(currentSum);
                    transition = 0;
                }
                else
                {
                    int currentDigit = currentSum % 10;
                    result.Add(currentDigit); // add the last digit of the summ
                    currentDigit = currentSum /= 10; // remove the last digit of the sum 
                    transition = currentDigit; // add the first digit of the sum to the  transition

                    if (i == firstArray.Count - 1 && transition != 0) // If we have two transitions example 99 + 99
                    {
                        result.Add(transition);
                    }
                }
            }

            return result;
        }
        private static List<int> InitialiseIntarray(string input, int size)
        {
            List<int> array = new List<int>();
            int[] numbers = input
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < size; i++)
            {
                if (i < numbers.Length)
                {
                    array.Add(numbers[i]); // add the digit from the input 
                }
                else
                {
                    array.Add(0); // fill the rest with zeroes
                }
            }

            return array;
        }
    }
}
