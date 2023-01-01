namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T element)
            {
                Element = element;
            }

            public Node(T element, Node next)
                : this(element)
            {
                Next = next;
            }

            public T Element { get; set; }

            public Node Next { get; set; }

        }

        private Node head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item, this.head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }

            this.Count++;
        }


        public T GetFirst()
        {
            CheckForEmptyCollection();

            return this.head.Element;
        }

        public T GetLast()
        {
            CheckForEmptyCollection();

            var node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            CheckForEmptyCollection();
            var oldNode = this.head;
            this.head = this.head.Next;
            this.Count--;

            return oldNode.Element;
        }

        public T RemoveLast()
        {
            CheckForEmptyCollection();

            T element;
            if (this.Count == 1)
            {
                element = this.head.Element;
                this.head = null;
                this.Count--;

                return element;
            }

            var node = this.head;
            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            element = node.Next.Element;
            node.Next = null;
            this.Count--;

            return element;
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

        private void CheckForEmptyCollection()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Empty collection");
            }
        }
    }
}