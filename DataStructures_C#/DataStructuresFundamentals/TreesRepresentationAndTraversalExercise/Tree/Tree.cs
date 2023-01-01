namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.children.Add(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        public IEnumerable<T> GetInternalKeys() =>
            this.GetKeysByCondition(x => x.Children.Count > 0).Select(x => x.Key);

        public IEnumerable<T> GetLeafKeys() =>
            this.GetKeysByCondition(x => x.Children.Count == 0).Select(x => x.Key);

        public T GetDeepestKey() => this.GetDeepestNode().Key;

        public IEnumerable<T> GetLongestPath()
        {
            var leaf = this.GetDeepestNode();
            var stack = new Stack<T>();
            var current = leaf;
            while (current.Parent != null)
            {
                stack.Push(current.Key);
                current = current.Parent;
            }
            stack.Push(this.Key);

            return stack;
        }

        public IEnumerable<T> GetPath(Tree<T> leaf)
        {
            var stack = new Stack<T>();
            var current = leaf;
            while (current.Parent != null)
            {
                stack.Push(current.Key);
                current = current.Parent;
            }
            stack.Push(this.Key);

            return stack;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = this.GetKeysByCondition(x => x.Children.Count == 0);
            Tree<T> deepestNode = null;
            int maxCount = 0;

            foreach (var leaf in leafs)
            {
                int count = 0;
                var current = leaf;
                while (current.Parent != null)
                {
                    count++;
                    current = current.Parent;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        protected IEnumerable<Tree<T>> GetKeysByCondition(Predicate<Tree<T>> condition)
        {
            List<Tree<T>> result = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                var children = currentNode.Children.Where(condition.Invoke);
                if (children.Any())
                {
                    result.AddRange(children);
                }

                foreach (var item in currentNode.Children)
                {
                    queue.Enqueue(item);
                }

            }

            return result;
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent);
            sb.AppendLine(tree.Key.ToString());
            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }
        }
    }
}
