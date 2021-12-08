using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : IAddCollection, IRemoveCollection
    {
        private readonly List<string> items;

        public AddRemoveCollection()
        {
            this.items = new List<string>();
        }

        public int Add(string item)
        {
            if (this.items != null)
            {
                this.items.Insert(0, item);
                return 0;
            }
            return -1;
        }

        public string Remove()
        {
            if (this.items != null)
            {
                int index = this.items.Count - 1;
                string item = this.items[index];
                this.items.RemoveAt(index);
                return item;
            }
            return null;
        }
    }
}
