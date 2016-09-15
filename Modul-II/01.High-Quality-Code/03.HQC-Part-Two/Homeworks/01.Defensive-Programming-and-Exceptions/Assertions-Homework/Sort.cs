using System;
using System.Diagnostics;

namespace Assertions_Homework
{
    public static class Sort
    {
        public static void SelectionSort<T>(T[] arr)
           where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 0, "The array is empty!");
            Debug.Assert(arr != null, "The array can't be null!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
           where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 0, "The array is empty");
            Debug.Assert(arr != null, "The array can't be null!");
            Debug.Assert(startIndex >= 0, "The start index must be >= 0");
            Debug.Assert(endIndex < arr.Length, "The end index must be < arr.length");
            Debug.Assert(startIndex <= endIndex, "The start index must be <= than the end index");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "The value x is null");
            Debug.Assert(y != null, "The value y is null");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
