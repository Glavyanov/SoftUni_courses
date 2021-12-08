using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> items;
        public AddCollection()
        {
            this.items = new List<string>();
        }
        public int Add(string item)
        {
            if (this.items != null)
            {
                this.items.Add(item);
                return this.items.LastIndexOf(item);
            }
            return -1;
        }
    }
}
