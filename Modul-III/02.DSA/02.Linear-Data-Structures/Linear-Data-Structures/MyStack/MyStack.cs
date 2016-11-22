namespace MyStack
{
    public class MyStack<T>
    {
        private T[] array;
        private int capacity = 8;
        private int index = 0;

        public MyStack()
        {
            this.array = new T[8];
        }

        public void Push(T item)
        {
            if (this.Count >= this.capacity)
            {
                this.IncreaseCapacity(); 
            }

            this.array[index] = item;
            this.Count++;
            this.index++;
        }

        private void IncreaseCapacity()
        {
            this.capacity *= 2;
            var newArray = new T[this.capacity];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        public T Pop()
        {
            var item = this.array[index - 1];
            this.index--;
            this.Count--;

            return item;
        }

        public T Peek()
        {
            return this.array[index - 1];
        }

        public int Count { get; private set; }
    }
}
