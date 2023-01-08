namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            List<T> firstElements = this.FindBfs(first);
            List<T> secondElements = this.FindBfs(second);

            if (firstElements is null || secondElements is null)
            {
                throw new InvalidOperationException();
            }

            return firstElements.Intersect(secondElements).Last();
        }

        private List<T> FindBfs(T element)
        {
            List<T> result = new List<T>();

            var current = this;
            while (current != null)
            {
                if (current.Value.CompareTo(element) < 0)
                {
                    result.Add(current.Value);
                    current = current.RightChild;
                }
                else if (current.Value.CompareTo(element) > 0)
                {
                    result.Add(current.Value);
                    current = current.LeftChild;
                }
                else
                {
                    result.Add(current.Value);
                    return result;
                }
            }

            return null;
        }
    }
}
