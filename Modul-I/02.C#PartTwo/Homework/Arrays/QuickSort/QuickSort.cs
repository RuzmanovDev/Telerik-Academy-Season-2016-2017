namespace QuickSort
{
    using System;

    class QuickSort
    {
        static void QuickSortLogic(int[] numbers, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(numbers, start, end);
                QuickSortLogic(numbers, start, partitionIndex - 1);
                QuickSortLogic(numbers, partitionIndex + 1, end);
            }
        }

        private static int Partition(int[] numbers, int start, int end)
        {
            int pivot = numbers[end];

            int partiotionIndex = start;

            for (int i = start; i < end; i++)
            {
                if (numbers[i] <= pivot)
                {
                    
                    Swap(ref numbers[i], ref numbers[partiotionIndex]);
                    //int tempValue = numbers[i];
                    //numbers[i] = numbers[partiotionIndex];
                    //numbers[partiotionIndex] = tempValue;
                    partiotionIndex++;
                }
            }
            Swap(ref numbers[partiotionIndex], ref numbers[end]);
            //int temp = numbers[partiotionIndex];
            //numbers[partiotionIndex] = numbers[end];
            //numbers[end] = temp;
            return partiotionIndex;
        }

        private static void Swap(ref int v1, ref int v2)
        {
            int temp = v2;
            v2 = v1;
            v1 = temp;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            QuickSortLogic(numbers, 0, numbers.Length - 1);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
