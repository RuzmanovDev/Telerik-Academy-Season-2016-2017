namespace SpecialValue
{
    using System;
    using System.Linq;

    class SpecialValue
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[][] numbers = new int[n][];
            bool[][] visited = new bool[n][];
            // read input 
            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                numbers[i] = new int[nums.Length];
                visited[i] = new bool[nums.Length];

                for (int j = 0; j < nums.Length; j++)
                {
                    numbers[i][j] = nums[j];
                }
            }

            // print the jagged array
            //for (int i = 0; i < n; i++)
            //{
            //    for (int c = 0; c < numbers[i].Length; c++)
            //    {
            //        Console.Write(numbers[i][c] + " ");
            //    }

            //    Console.WriteLine();
            //}

            int pathLength = 0;

            int specialValue = 0;
            int maxSpecialValue = int.MinValue;

            int row = 0;
            int col = 0;

            for (int i = 0; i < numbers[0].Length; i++)
            {
                VisitedFalse(visited);
                int startIndex = numbers[0][i];
                pathLength = 0;
                if (startIndex < 0)
                {
                    pathLength++;
                    // no need to check if it's visited because it is resetted ^^
                    specialValue = FoundNegative(pathLength, startIndex);
                    maxSpecialValue = Math.Max(specialValue, maxSpecialValue);
                    continue;
                }

                int currentNumber = startIndex;
                row = 0;
                col = i;
                while (true)
                {
                    if (currentNumber < 0 || visited[row][col])
                    {
                        pathLength++;
                        if (!visited[row][col])
                        {
                            specialValue = FoundNegative(pathLength, currentNumber);
                        }
                        maxSpecialValue = Math.Max(specialValue, maxSpecialValue);
                        visited[row][col] = true;
                        pathLength = 0;
                        break;
                    }
                    else
                    {
                        if (visited[row][col])
                        {
                            break;
                        }
                        visited[row][col] = true;

                        row++;
                        if (row >= n)
                        {
                            row = 0;
                        }
                        col = currentNumber;
                        currentNumber = numbers[row][col];
                        // visited[row][col] = true;
                        pathLength++; // visited = true 

                    }
                }
            }

            Console.WriteLine(maxSpecialValue);
        }

        private static int FoundNegative(int pathLength, int negativeNumber)
        {
            int value = pathLength + Math.Abs(negativeNumber);
            return value;
        }

        private static void VisitedFalse(bool[][] visited)
        {
            for (int r = 0; r < visited.Length; r++)
            {
                visited[r] = new bool[visited[r].Length];
            }
        }
    }
}