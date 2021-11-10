using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones;

        public Lake(params int[] stones)
        {
            this.stones = stones.ToList();
            this.Count = this.stones.Count;
        }

        public int Count { get; private set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }
            this.Count = this.Count % 2 == 0 ? this.Count : --this.Count;

            for (int i = this.Count - 1; i >= 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
