namespace Exercises_5_7
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using VersionAttribute; // conflicts with the System namespace

    [VersionAttribute.Version(1, 1)]
    public class MyList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
        where T : IComparable<T>
    {
        private const int InitialCapacity = 4;

        private T[] array;
        private int capacity;
        private int count;

        public MyList()
        {
            this.array = new T[InitialCapacity];
            this.Count = 0;
            this.Capacity = InitialCapacity;
        }

        public MyList(int size)
        {
            this.array = new T[size];
            this.Capacity = size;
            this.Count = 0;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The capacity of the list can't be less than 0");
                }

                this.capacity = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Count of the list can't be less than 0");
                }

                this.count = value;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException("The index is outside of he boundries of he array!");
                }

                return this.array[index];
            }

            set
            {
                if (index < 0 || index > this.Capacity)
                {
                    throw new IndexOutOfRangeException("The index is outside of he boundries of he array!");
                }

                this.array[index] = value;
            }
        }

        public void Add(T element)
        {
            this.EnsureCapacity();
            this.array[this.count] = element;
            this.Count++;
        }

        public void Clear()
        {
            this.array = new T[this.Capacity];
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            bool contains = false;
            foreach (var i in this.array)
            {
                if (i.Equals(item))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new NullReferenceException("The array cannot be copied to Not instanced one");
            }

            Array.Copy(this.array, array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var item = this.array[i];
                yield return item;
            }
        }

        public int IndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            if (0 > index)
            {
                throw new IndexOutOfRangeException("The index is outisde of the boundries!");
            }

            if (index == this.array.Length)
            {
               this.EnsureCapacity();
            }

            T temp = this.array[index];
            this.array[index] = item;

            for (int i = index + 1; i < this.array.Length - 1; i++)
            {
                var temValue = this.array[i];
                this.array[i] = temp;
                temp = temValue;
            }
        }

        public bool Remove(T item)
        {
            bool isRemoved = false;
            bool contsins = this.Contains(item);
            if (contsins)
            {
                var temp = this.array;
                this.array = new T[this.array.Length - 1];
                this.Count = 0;
                var index = Array.IndexOf(temp, item);

                for (int i = 0; i < index; i++)
                {
                    this.Add(temp[i]);
                }

                for (int i = index; i < temp.Length - index; i++)
                {
                    this.Add(temp[i + 1]);
                }

                isRemoved = true;
            }

            return isRemoved;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.array.Length)
            {
                throw new IndexOutOfRangeException("The index is outside of the boundries of the array!");
            }

            var temp = this.array;
            this.array = new T[InitialCapacity];
            this.Capacity = InitialCapacity;
            this.Count = 0;

            for (int i = 0; i < index; i++)
            {
                this.Add(temp[i]);
            }

            for (int i = index; i < temp.Length - index; i++)
            {
                this.Add(temp[i + 1]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                builder.Append(this[i] + ", ");
            }

            return builder.ToString().Trim(new char[] { ',', ' ' });
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("There are no elements in the GenericList");
            }

            T min = this.array[0];

            for (int i = 0; i <= this.Count; i++)
            {
                T item = this[i];
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("There are no elements in the GenericList");
            }

            T max = this.array[0];

            foreach (T item in this.array)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        private void EnsureCapacity()
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity *= 2;

                T[] oldArray = this.array;
                this.array = new T[this.Capacity];

                for (int i = 0; i < oldArray.Length; i++)
                {
                    this.array[i] = oldArray[i];
                }
            }
        }
    }
}