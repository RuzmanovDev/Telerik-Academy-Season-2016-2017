using System;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class MyLinkedList<T>
    {
        public ListItem<T> Head { get; private set; }

        public ListItem<T> Tail { get; private set; }

        public int Count { get; set; }


        public MyLinkedList() { }

        public MyLinkedList(ListItem<T> item)
        {
            this.Head = item;
            this.Tail = item;
            this.Count++;
        }

        public MyLinkedList(T value)
        {
            var listElement = new ListItem<T>(value);
            this.Head = listElement;
            this.Tail = listElement;
            this.Count++;
        }

        public void Append(ListItem<T> item)
        {
            if (this.Head == null)
            {
                this.Head = item;
            }
            else
            {
                this.Tail.Next = item;
            }

            this.Tail = item;
            this.Count++;
        }

        public void Prepend(ListItem<T> item)
        {
            if (this.Count == 0)
            {
                this.Append(item);
            }
            else
            {
                var oldHead = this.Head;

                this.Head = item;
                this.Head.Next = oldHead;

                if (this.Count == 1)
                {
                    this.Head = this.Tail;
                }

                this.Count++;
            }
        }

        public void RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The list is alread empty!");
            }
            var newHead = this.Head.Next;
            this.Head = newHead;

            this.Count--;
        }

        public void RemoveLast()
        {
            var currentNode = this.Head;

            while (currentNode != this.Tail)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = null;
            this.Tail = currentNode;

            this.Count--;
        }

        public T[] ToArray()
        {
            var node = this.Head;
            var array = new T[this.Count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var values = this.ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                yield return values[i];
            }
        }

        public void Add(T item)
        {
            this.Append(new ListItem<T>(item));
        }

        public override string ToString()
        {
            var result = string.Join(" -> ", this.ToArray());

            return result;
        }

    }
}
