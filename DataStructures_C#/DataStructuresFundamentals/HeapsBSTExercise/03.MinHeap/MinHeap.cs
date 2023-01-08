namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        public T ExtractMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T result = this.elements[0];

            (this.elements[0], this.elements[this.Count - 1]) = (this.elements[this.Count - 1], this.elements[0]);

            this.elements.RemoveAt(this.Count - 1);
            this.HeapifyDown(0);

            return result;
        }

        public T Peek()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }

        private void HeapifyDown(int index)
        {
            int smallerChildIndex = this.GetSmallerChildIndex(index);

            while (this.IsValidIndex(smallerChildIndex) && this.elements[index].CompareTo(this.elements[smallerChildIndex]) > 0)
            {
                (this.elements[index], this.elements[smallerChildIndex]) = (this.elements[smallerChildIndex], this.elements[index]);
                index = smallerChildIndex;
                smallerChildIndex = this.GetSmallerChildIndex(index);
            }
        }

        private int GetSmallerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (this.IsValidIndex(secondChildIndex))
            {
                if (this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) < 0)
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (this.IsValidIndex(firstChildIndex))
            {
                return firstChildIndex;
            }
            else
            {
                return -1;
            }
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) < 0)
            {
                (this.elements[index], this.elements[parentIndex]) = (this.elements[parentIndex], this.elements[index]);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }
    }
}
