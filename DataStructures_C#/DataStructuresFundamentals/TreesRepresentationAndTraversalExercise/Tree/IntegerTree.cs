namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<IEnumerable<int>>();
            var leafs = base.GetKeysByCondition(x => x.Children.Count is 0);

            foreach (var leaf in leafs)
            {
                var currentLeaf = leaf;
                var currentSum = this.Key;
                while (currentLeaf.Parent != null)
                {
                    currentSum += currentLeaf.Key;
                    currentLeaf = currentLeaf.Parent;
                }
                if (currentSum == sum)
                {
                    result.Add(base.GetPath(leaf));
                }
            }

            return result;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();
            var queue = new Queue<Tree<int>>();
            queue.Enqueue(this);

            if (this.sumBfs(this) == sum)
            {
                result.Add(this);
            }

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                foreach (var tree in current.Children)
                {
                    if (this.sumBfs(tree) == sum) 
                    {
                        result.Add(tree);
                    }
                    queue.Enqueue(tree);
                }
            }

            return result;

        }

        public string GetAsString() => base.AsString();

        public List<int> GetMiddleKeys() => base.GetInternalKeys().ToList();

        public int GetDeepestLeftomostNode() => base.GetDeepestKey(); // for Judge must be return Tree<int> !!!
        private int sumBfs(Tree<int> tree)
        {
            var queue = new Queue<Tree<int>>(new List<Tree<int>>() { tree });
            int result = 0;
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result += subtree.Key;

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
