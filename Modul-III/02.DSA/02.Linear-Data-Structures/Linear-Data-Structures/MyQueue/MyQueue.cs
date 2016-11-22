using System.Collections.Generic;

namespace MyQueue
{
    public class MyQueue<T>
    {
        private LinkedList<T> queue;

        public MyQueue()
        {
            this.queue = new LinkedList<T>();
        }

        public void Enque(T item)
        {
            this.queue.AddLast(item);
            this.Count++;
        }

        public T Dequeu()
        {
            var valueToReturn = this.queue.First.Value;
            this.queue.RemoveFirst();
            this.Count--;

            return valueToReturn;
        }

        public T Peek()
        {
            return this.queue.First.Value;
        }

        public int Count { get; private set; }
    }
}
