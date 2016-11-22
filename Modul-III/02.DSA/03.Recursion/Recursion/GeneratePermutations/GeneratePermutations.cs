using System;

namespace GeneratePermutations
{
    public class GeneratePermutations
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            } 

            Permutation(0, numbers);
        }

        private static void Permutation(int num, int[] numbers)
        {
            if (num >= numbers.Length)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            Permutation(num + 1, numbers);

            for (int i = num + 1; i < numbers.Length; i++)
            {
                Swap(ref numbers[num], ref numbers[i]);
                Permutation(num + 1, numbers);
                Swap(ref numbers[num], ref numbers[i]);
            }
        }

        private static void Swap(ref int firstNum, ref int secondNum)
        {
            int oldValue = firstNum;
            firstNum = secondNum;
            secondNum = oldValue;
        }
    }
}
