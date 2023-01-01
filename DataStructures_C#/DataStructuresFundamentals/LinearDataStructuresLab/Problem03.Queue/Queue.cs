namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T element)
            {
                Element = element;
            }

            public Node(T element, Node next)
                :this(element)
            {
                Next = next;    
            }

            public T Element { get; set; }

            public Node Next { get; set; }

        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);
            var node = this.head;
            if (node == null)
            {
                this.head = newNode;
            }
            else
            {
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }
            
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Empty collection");
            }

            var oldNode = this.head;
            this.head = this.head.Next;
            this.Count--;

            return oldNode.Element;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Empty collection");
            }

            return this.head.Element;
        }

        public bool Contains(T item)
        {
            var node = this.head;
            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}