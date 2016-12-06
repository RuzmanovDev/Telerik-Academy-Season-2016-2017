using System;
using System.Collections;
using System.Collections.Generic;

namespace SortingHomework
{
    public class SortableCollection<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly IList<T> items;
        private readonly Random random;

        public SortableCollection()
        {
            this.items = new List<T>();
            // I know bastered injection ...
            this.random = new Random();

        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            this.random = new Random();
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.items)
            {
                if (element.CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int leftIndex = 0;
            int rightIndex = items.Count;


            while (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;

                T currentItem = this.items[middleIndex];
                if (currentItem.CompareTo(item) == 0)
                {
                    return true;
                }

                if (currentItem.CompareTo(item) > 1)
                {
                    rightIndex = middleIndex;
                }
                else if (currentItem.CompareTo(item) < 1)
                {
                    leftIndex = middleIndex + 1;
                }

            }

            return false;
        }

        public void Shuffle()
        {

            for (int i = 0; i < this.items.Count - 1; i++)
            {
                int randIndex = random.Next(i + 1, items.Count);
                T temp = this.items[i];
                this.items[i] = this.items[randIndex];
                this.Items[randIndex] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
