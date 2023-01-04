namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {

        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        public T ExtractMax()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            T result = this.elements[0];

            (this.elements[0], this.elements[this.Size - 1]) = (this.elements[this.Size - 1], this.elements[0]);

            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return result;
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                (this.elements[index], this.elements[parentIndex]) = (this.elements[parentIndex], this.elements[index]);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            var biggerChildIndex = this.GetBiggerChildIndex(index);

            while (this.IsValidIndex(biggerChildIndex) && this.elements[index].CompareTo(this.elements[biggerChildIndex]) < 0)
            {

                (this.elements[index], this.elements[biggerChildIndex]) = (this.elements[biggerChildIndex], this.elements[index]);
                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        private int GetBiggerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (this.IsValidIndex(secondChildIndex))
            {
                if (this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) > 0)
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

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }
    }
}
