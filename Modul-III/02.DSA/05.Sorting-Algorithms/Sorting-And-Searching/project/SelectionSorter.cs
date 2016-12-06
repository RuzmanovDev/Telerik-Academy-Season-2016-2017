using System;
using System.Collections.Generic;

namespace SortingHomework
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) > 0)
                    {
                        var temp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
        }
    }
}
