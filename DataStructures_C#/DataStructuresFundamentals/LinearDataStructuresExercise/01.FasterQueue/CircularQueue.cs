namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DEFAULT_CAPACITY = 4;

        private T[] elements;

        private int startIndex = 0;

        private int endIndex = 0;

        public CircularQueue(int capacity = DEFAULT_CAPACITY)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }

            this.Count--;
            return this.elements[this.startIndex++];
        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }


        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            return this.elements[startIndex];
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            return arr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[(this.startIndex + i) % this.elements.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Grow()
        {
            for (int i = 0; i < this.Count; i++)
            {
                int index = (this.startIndex + i) % this.elements.Length;
                (this.elements[index], this.elements[i]) = (this.elements[i], this.elements[index]);
            }
            this.startIndex = 0;
            this.endIndex = this.Count;

            this.elements = this.elements.Concat(new T[this.Count]).ToArray();
        }
    }

}
