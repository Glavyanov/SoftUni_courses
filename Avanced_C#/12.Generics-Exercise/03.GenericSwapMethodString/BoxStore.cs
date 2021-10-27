using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class BoxStore<T>
    {
        private readonly List<T> boxes;

        public BoxStore()
        {
            this.boxes = new List<T>();
        }

        public void AddBox(T box)
        {
            this.boxes.Add(box);
        }

        public void Swap(int each, int another)
        {
            if (this.boxes.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            bool invalidIndex = each < 0 || another < 0 || each >= this.boxes.Count || another >= this.boxes.Count;
            if (invalidIndex)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            else
            {
                var temp = this.boxes[each];
                this.boxes[each] = this.boxes[another];
                this.boxes[another] = temp;
            }

        }

        public void Print()
        {
            foreach (var item in boxes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
