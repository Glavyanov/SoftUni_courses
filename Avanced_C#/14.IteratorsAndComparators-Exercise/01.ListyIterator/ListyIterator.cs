using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;

        private int index;

        public ListyIterator(params T[] items)
        {
            this.items = items.ToList();
            this.index = 0;
        }

        public bool Move() => this.HasNext() ? this.index++ > -1 : this.HasNext();
        //{
        //    if (this.HasNext())
        //    {
        //        this.index++;
        //        return true;
        //    }
        //    return false;
        //}

        public bool HasNext() => this.index < this.items.Count - 1;

        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.items[this.index]);
        }
        
    }
}
