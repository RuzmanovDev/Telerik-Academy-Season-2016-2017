using System;

namespace Task3
{
    public class LoopRefactor
    {
        private const int SeekedValue = 666;

        private void Loop(int[] numbers, int expectedValue)
        {
            int foundValue = 0;

            for (int i = 0; i < numbers.Length;)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(numbers[i]);
                    if (numbers[i] == expectedValue)
                    {
                        foundValue = SeekedValue;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(numbers[i]);
                }
            }

            // More code here
            if (foundValue == SeekedValue)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
