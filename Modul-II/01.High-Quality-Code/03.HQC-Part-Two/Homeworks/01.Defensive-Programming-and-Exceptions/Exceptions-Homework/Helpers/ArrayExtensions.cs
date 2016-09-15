using System;
using System.Collections.Generic;

namespace Exceptions_Homework.Helpers
{
    public static class ArrayExtensions
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("The arr must not be null!");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"The value of startindex: {startIndex} must be >= 0!");
            }

            if (startIndex > count)
            {
                throw new ArgumentOutOfRangeException($"The value of the start index: {startIndex} can't be > than the count: {count}!");
            }

            if (count > arr.Length)
            {
                throw new ArgumentOutOfRangeException($"The value of the count: {count} must be <= that the array's length: {arr.Length}");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }
    }
}
