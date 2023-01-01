namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private Tree<T> parent;

        private readonly List<Tree<T>> children;

        private T value;

        private List<T> dfsResult;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
            this.dfsResult = new List<T>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindParentWithBfs(parentKey);
            if (parentNode is null)
            {
                throw new ArgumentNullException("No such elements in collection!");
            }

            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>(new List<Tree<T>>() { this });
            var result = new List<T>();
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            foreach (var child in this.children)
            {
                var collection = child.OrderDfs();
                this.dfsResult = this.dfsResult.Concat(collection).ToList();
                this.dfsResult.Add(child.value);
            }
            if (this.parent is null)
            {
                this.dfsResult.Add(this.value);
            }

            return this.dfsResult;
        }

        public void RemoveNode(T nodeKey)
        {
            var nodeForDelete = this.FindParentWithBfs(nodeKey);
            if (nodeForDelete is null)
            {
                throw new ArgumentNullException("No such element in collection!");
            }

            if (nodeForDelete.parent is null)
            {
                throw new ArgumentException("Can not delete root element!");
            }

            nodeForDelete.parent.children.Remove(nodeForDelete);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var leftNode = this.FindWithDfs(firstKey, this);
            var rightNode = this.FindWithDfs(secondKey, this);

            if (leftNode is null || rightNode is null)
            {
                throw new ArgumentNullException(leftNode is null ? nameof(leftNode) : nameof(rightNode));
            }

            var leftParent = leftNode.parent;
            var rightParent = rightNode.parent;

            if (leftParent is null || rightParent is null)
            {
                throw new ArgumentException(leftParent is null ? nameof(leftParent) : nameof(rightParent));
            }

            var leftIndex = leftParent.children.IndexOf(leftNode);
            var rightIndex = rightParent.children.IndexOf(rightNode);
            leftParent.children[leftIndex] = rightNode;
            rightParent.children[rightIndex] = leftNode;
        }

        private Tree<T> FindWithDfs(T key, Tree<T> tree)
        {
            if (tree.value.Equals(key))
            {
                return tree;
            }
            foreach (var child in tree.children)
            {
                var result = this.FindWithDfs(key, child);
                if (result?.value.Equals(key) ?? false)
                {
                    return result;
                }
            }

            return null;
        }

        private Tree<T> FindParentWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>(new List<Tree<T>>() { this });

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
