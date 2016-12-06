using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingHomework
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            var left = collection.Take(collection.Count / 2).ToList();
            var right = collection.Skip(collection.Count / 2).ToList();

            MergeSort(left);
            MergeSort(right);

            Merge(collection, left, right);
        }

        private void Merge(IList<T> collection, List<T> left, List<T> right)
        {
            int index = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (left.Count > leftIndex && right.Count > rightIndex)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    collection[index] = left[leftIndex];
                    index++;
                    leftIndex++;
                }
                else
                {
                    collection[index] = right[rightIndex];
                    index++;
                    rightIndex++;
                }
            }

            while (left.Count > leftIndex)
            {
                collection[index] = left[leftIndex];
                index++;
                leftIndex++;
            }

            while (right.Count > rightIndex)
            {
                collection[index] = right[rightIndex];
                index++;
                rightIndex++;
            }
        }
    }
}
