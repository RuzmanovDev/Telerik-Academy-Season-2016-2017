using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GreedyDwarf
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputValley = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries); 
            long[] valley = ParseStringArrayToInt(inputValley);
            long numberOfPatterns = long.Parse(Console.ReadLine());
            long bestSumOfCoins = long.MinValue;
            for (int i = 0; i < numberOfPatterns; i++)
            {
                long sumOfCoins = 0;
                sumOfCoins += valley[0];
                string[] patternAsString = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long[] pattern = ParseStringArrayToInt(patternAsString);
                bool[] foundExit = new bool[valley.Length];
                foundExit[0] = true;
                long currentPosition = 0;
                bool flag = false;
                while (!flag)
                {
                    for (int j = 0; j < pattern.Length; j++)
                    {

                        long nextMove = currentPosition + pattern[j];
                        if (nextMove >= 0 
                            &&nextMove < valley.Length 
                            && !foundExit[nextMove])
                        {
                            sumOfCoins += valley[nextMove];
                            foundExit[nextMove] = true;
                            currentPosition = nextMove;
                          
                               
                        }
                        else
                        {
                            flag = true;
                        }
                    }

                }
                if (bestSumOfCoins < sumOfCoins)
                {
                    bestSumOfCoins = sumOfCoins;
                }
            }
            Console.WriteLine(bestSumOfCoins);

        }
        private static long[] ParseStringArrayToInt(string[] numbersAsString)
        {
            long[] numbers = new long[numbersAsString.Length];
            for (int i = 0; i < numbersAsString.Length; i++)
            {
                numbers[i] = long.Parse(numbersAsString[i]);
            }
            return numbers;
        }
    }
}
