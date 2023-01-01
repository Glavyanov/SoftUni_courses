namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            internal Node(T value)
            {
                this.Value = value;
            }

            public Node Next { get; set; }

            public Node Previous { get; set; }

            public T Value { get; set; }
        }

        private Node head;

        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item);
            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node(item);
            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                node.Previous = this.tail;
                this.tail = node;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Empty collection");

            }

            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException("Empty collection");

            }

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            var node = this.head;
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty collection");

            }
            else if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            this.Count--;
            return node.Value;
        }

        public T RemoveLast()
        {
            var node = this.tail;
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty collection");

            }
            else if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next= null;
            }

            this.Count--;
            return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}