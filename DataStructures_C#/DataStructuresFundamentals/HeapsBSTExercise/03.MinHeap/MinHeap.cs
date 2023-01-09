namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        protected Dictionary<T, int> indexes;

        public MinHeap()
        {
            this.elements = new List<T>();
            this.indexes = new Dictionary<T, int>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.indexes.Add(element, this.Count - 1);
            this.HeapifyUp(this.elements.Count - 1);
        }

        public T ExtractMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T result = this.elements[0];

            this.Swap(0, this.Count - 1);

            this.elements.RemoveAt(this.Count - 1);
            this.indexes.Remove(result);

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

        protected void HeapifyDown(int index)
        {
            int smallerChildIndex = this.GetSmallerChildIndex(index);

            while (this.IsValidIndex(smallerChildIndex) && this.elements[index].CompareTo(this.elements[smallerChildIndex]) > 0)
            {
                this.Swap(index, smallerChildIndex);

                index = smallerChildIndex;
                smallerChildIndex = this.GetSmallerChildIndex(index);
            }
        }

        protected void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) < 0)
            {
                this.Swap(index, parentIndex);

                index = parentIndex;
                parentIndex = (index - 1) / 2;
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

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }

        private void Swap(int index, int temp)
        {
            (this.elements[index], this.elements[temp]) = (this.elements[temp], this.elements[index]);
            this.indexes[this.elements[index]] = index;
            this.indexes[this.elements[temp]] = temp;
        }
    }
}
