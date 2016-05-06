namespace MergeSort
{
    using System;

    class MergeSort
    {
        static public void DoMerge(int[] numbers, int[] left, int[] right)
        {

            int smallesUnpickIndexInLeft = 0;
            int smallestUnpickIndexInRight = 0; 
            int indexInArray = 0; 

            while (smallesUnpickIndexInLeft < left.Length && smallestUnpickIndexInRight < right.Length)
            {
                if (left[smallesUnpickIndexInLeft] <= right[smallestUnpickIndexInRight])
                {
                    numbers[indexInArray] = left[smallesUnpickIndexInLeft];
                    indexInArray++;
                    smallesUnpickIndexInLeft++;
                }
                else
                {
                    numbers[indexInArray] = right[smallestUnpickIndexInRight];
                    indexInArray++;
                    smallestUnpickIndexInRight++;
                }
            }

            while (smallesUnpickIndexInLeft < left.Length)
            {
                numbers[indexInArray] = left[smallesUnpickIndexInLeft];
                indexInArray++;
                smallesUnpickIndexInLeft++;
            }

            while (smallestUnpickIndexInRight < right.Length)
            {
                numbers[indexInArray] = right[smallestUnpickIndexInRight];
                indexInArray++;
                smallestUnpickIndexInRight++;
            }

        }

        static public void MergeSortLogic(int[] numbers)
        {
            int size = numbers.Length;
            if (size < 2)
            {
                return;
            }

            int middle = size / 2;
            int[] left = new int[middle];
            int[] right = new int[size - middle];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = numbers[i];
            }
            for (int i = middle; i < size; i++)
            {
                right[i - middle] = numbers[i];
            }

            MergeSortLogic(left);
            MergeSortLogic(right);

            DoMerge(numbers, left, right);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            MergeSortLogic(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}

