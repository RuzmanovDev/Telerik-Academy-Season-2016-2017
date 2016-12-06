using System;
using System.Collections.Generic;

namespace SortingHomework
{
    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int j = i;

                while (j > 0 && collection[j].CompareTo(collection[j - 1]) <= 0)
                {
                    var temp = collection[j];
                    collection[j] = collection[j - 1];
                    collection[j - 1] = temp;
                    j--;
                }
            }
        }
    }
}
