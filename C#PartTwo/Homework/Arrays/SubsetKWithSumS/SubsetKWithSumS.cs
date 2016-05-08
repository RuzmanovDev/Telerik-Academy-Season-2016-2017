namespace SubsetKWithSumS
{
    using System;
    using System.Collections.Generic;
    
    // copy paste

    class SubsetKWithSumS
    {
        static List<int> bestSubset;
        static int n;
        static long sumToFind;
        static int k;
        static int[] array;

        static void Main(string[] args)
        {
            Input();

            long maxCombinations = (int)Math.Pow(2, n);

            for (long i = 1; i < maxCombinations; i++)
            {
                long numberForCombination = i;
                long sum = 0;

                List<int> numbersInSum = new List<int>();
                int bitNumber = 0;
                while (numberForCombination > 0 && bitNumber < n)
                {
                    long nextBit = numberForCombination & 1;
                    numberForCombination >>= 1;

                    if (nextBit == 1)
                    {
                        sum += array[bitNumber];
                        numbersInSum.Add(array[bitNumber]);
                        if (numbersInSum.Count > k)
                        {
                            continue;
                        }
                    }

                    bitNumber++;
                }
                if (sum == sumToFind && numbersInSum.Count == k)
                {
                    if (IsNewSubsetBiggerLexicographicaly(numbersInSum))
                    {
                        MakeBest(numbersInSum);
                    }
                }
            }
            if (bestSubset.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                PrintSubset(bestSubset);
            }
        }
        private static void PrintSubset(List<int> bestSubset)
        {
            for (int i = 0; i < bestSubset.Count; i++)
            {
                Console.Write("{0} ", bestSubset[i]);
            }
            Console.WriteLine();
        }
        private static void MakeBest(List<int> newSubsetIndexes)
        {
            bestSubset = new List<int>(newSubsetIndexes.Count);
            for (int i = 0; i < newSubsetIndexes.Count; i++)
            {
                bestSubset.Add(newSubsetIndexes[i]);
            }
        }

        private static bool IsNewSubsetBiggerLexicographicaly(List<int> newSubsetIndexes)
        {
            int index = 0;
            bool newSubsetIsBigger = true;
            while (index < newSubsetIndexes.Count && index < bestSubset.Count)
            {
                if (bestSubset[index] == newSubsetIndexes[index])
                {
                    index++;
                }
                else
                {
                    newSubsetIsBigger = bestSubset[index] < newSubsetIndexes[index];
                    break;
                }
            }
            return newSubsetIsBigger;
        }
        private static void Input()
        {
            n = int.Parse(Console.ReadLine());
            sumToFind = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            bestSubset = new List<int>();
        }


    }
}

