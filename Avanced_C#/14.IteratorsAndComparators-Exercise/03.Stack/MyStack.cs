using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public int Count { get; private set; }

        public MyStack()
        {
            this.items = new List<T>();
            this.Count = 0;
        }

        public void Push(T item)
        {
            this.items.Add(item);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            T item = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            this.Count--;
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
