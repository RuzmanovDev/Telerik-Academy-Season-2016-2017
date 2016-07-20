namespace GreedyDwarf
{
    using System;
    using System.Linq;

    class GreedyDwarf
    {
        static void Main(string[] args)
        {
            long[] valley = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();


            int m = int.Parse(Console.ReadLine());
            long maxSum = long.MinValue;

            for (int i = 0; i < m; i++)
            {
                long[] pattern = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                bool[] visitted = new bool[valley.Length];
                long position = 0;

                //get the first value
                long currentSum = valley[0];
                visitted[0] = true;
                long patternIndex = 0;

                while (true)
                {
                    position += pattern[patternIndex];

                    if (position < 0 || position > valley.Length - 1)
                    {
                        break;
                    }

                    if (!visitted[position])
                    {
                        currentSum += valley[position];
                        visitted[position] = true;
                    }
                    else
                    {
                        break;
                    }

                    patternIndex++;
                    if (patternIndex > pattern.Length - 1)
                    {
                        patternIndex = 0;
                    }
                }

                maxSum = Math.Max(maxSum, currentSum);
            }

            Console.WriteLine(maxSum);
        }
    }
}

