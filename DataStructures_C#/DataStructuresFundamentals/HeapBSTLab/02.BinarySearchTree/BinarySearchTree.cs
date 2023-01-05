namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {

        private class Node
        {

            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public Node LeftChild { get; set; }

            public Node RightChild { get; set; }

        }

        private Node root;

        public BinarySearchTree()
        {

        }

        private BinarySearchTree(Node node)
        {
            this.PreOrderFullCopy(node);
        }

        private void PreOrderFullCopy(Node node)
        {
            if (node is null) 
                return;

            this.Insert(node.Value);
            this.PreOrderFullCopy(node.LeftChild);
            this.PreOrderFullCopy(node.RightChild);
        }

        public bool Contains(T element) =>  this.Contains(element, this.root) != null;

        public void EachInOrder(Action<T> action) => this.EachInOrder(action, this.root);

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.Contains(element, this.root);

            if (node is null)
                return null;

            IBinarySearchTree<T> tree = new BinarySearchTree<T>(node);

            return tree;
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node is null)
                return;

            this.EachInOrder(action, node.LeftChild);

            action.Invoke(node.Value);

            this.EachInOrder(action, node.RightChild);
        }

        private Node Insert(T element, Node node)
        {
            if (node is null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.LeftChild = this.Insert(element, node.LeftChild);

            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.RightChild = this.Insert(element, node.RightChild);

            }


            return node;
        }

        private Node Contains(T element, Node node)
        {
            if (node is null)
            {
                return node;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return this.Contains(element, node.LeftChild);
            }
            else if (node.Value.CompareTo(element) < 0)
            {
                return this.Contains(element, node.RightChild);
            }
            else
            {
                return node;
            }
        }
    }
}
