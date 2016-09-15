using System;
using System.Diagnostics;

namespace Assertions_Homework
{
    public static class Search
    {
        public static int BinarySearch<T>(T[] arr, T value)
           where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 0, "The array is empty");
            Debug.Assert(value != null, "The value is null");

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 0, "The array is empty");
            Debug.Assert(startIndex >= 0, "The start index must be >= 0");
            Debug.Assert(endIndex < arr.Length, "The end index must be < arr.length");
            Debug.Assert(startIndex <= endIndex, "The start index must be <= than the end index");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
