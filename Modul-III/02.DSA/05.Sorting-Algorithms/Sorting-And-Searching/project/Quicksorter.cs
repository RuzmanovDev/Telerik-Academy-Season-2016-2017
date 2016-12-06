using System;
using System.Collections.Generic;

namespace SortingHomework
{

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(IList<T> collection, int start, int end)
        {
            if (start < end)
            {
                int k = Partition(collection, start, end);
                this.Quicksort(collection, start, end - 1);
                this.Quicksort(collection, start + 1, end);
            }
        }

        private int Partition(IList<T> collection, int start, int end)
        {
            var pivot = collection[end];

            int index = (start - 1);
            for (int i = start; i <= end - 1; i++)
            {
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    index++;
                    var temp = collection[i];
                    pivot = collection[i];
                    collection[i] = pivot;
                }
            }

            var t = collection[index + 1];
            collection[index + 1] = collection[end];
            collection[end] = t;

            return index + 1;
        }


    }
}
