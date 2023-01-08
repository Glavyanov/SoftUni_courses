namespace _01.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.Delete(this.root, element);
        }

        public void DeleteMax()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);
        }

        public void DeleteMin()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMin(this.root);
        }

        public int Count()
        {
            return this.Count(this.root);
        }

        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        public T Select(int rank)
        {
            Node node = this.Select(this.root, rank);

            if (node is null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            List<T> result = new List<T>();

            this.Range(this.root, startRange, endRange, result);

            return result;
        }

        private void Range(Node node, T startRange, T endRange, List<T> result)
        {
            if (node is null)
            {
                return;
            }

            bool leftTurn = startRange.CompareTo(node.Value) < 0;
            bool rightTurn = endRange.CompareTo(node.Value) > 0;

            if (leftTurn)
            {
                this.Range(node.Left, startRange, endRange, result);
            }

            if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                result.Add(node.Value);
            }

            if (rightTurn)
            {
                this.Range(node.Right, startRange, endRange, result);
            }

        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left is null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);

            return node;
        }

        private Node Select(Node node, int rank)
        {
            if (node is null)
            {
                return null;
            }

            int leftCount = this.Count(node.Left);

            if (leftCount == rank)
            {
                return node;
            }
            else if (leftCount > rank)
            {
                return this.Select(node.Left, rank);
            }
            else
            {
                return this.Select(node.Right, rank - (leftCount + 1));
            }

        }

        private int Rank(T element, Node node)
        {
            if (node is null)
            {
                return 0;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Rank(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                int testLeft = this.Count(node.Left);
                int testRight = this.Rank(element, node.Right);
                return 1 + testLeft + testRight;
            }

            return this.Count(node.Left);
        }

        private int Count(Node node)
        {
            if (node is null)
            {
                return 0;
            }

            int count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return count;
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right is null)
            {
                return node.Left;
            }
            node.Right = this.DeleteMax(node.Right);

            return node;
        }

        private Node FindMinElement(Node node)
        {
            if (node.Left is null)
            {
                return node;
            }
            node = FindMinElement(node.Left);

            return node;
        }

        private Node Delete(Node nodeToDelete, T element)
        {

            if (nodeToDelete.Value.Equals(element) && nodeToDelete.Right is null)
            {
                return nodeToDelete.Left;
            }

            if (nodeToDelete.Value.Equals(element) && nodeToDelete.Left is null && nodeToDelete.Right.Left is null)
            {
                return nodeToDelete.Right;
            }
            
            if (element.CompareTo(nodeToDelete.Value) < 0)
            {
                nodeToDelete.Left = this.Delete(nodeToDelete.Left, element);
            }
            else if (element.CompareTo(nodeToDelete.Value) > 0)
            {
                nodeToDelete.Right = this.Delete(nodeToDelete.Right, element);
            }

            if (nodeToDelete.Value.Equals(element))
            {
                var right = nodeToDelete.Right;
                var left = nodeToDelete.Left;
                nodeToDelete = this.FindMinElement(nodeToDelete.Right);
                right = this.DeleteMin(right);
                nodeToDelete.Left = left;
                nodeToDelete.Right = right;
                return nodeToDelete;
            }

            return nodeToDelete;
        }

    }
}
