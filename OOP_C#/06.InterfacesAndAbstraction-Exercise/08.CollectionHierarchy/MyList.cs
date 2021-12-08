using System.Collections.Generic;
using System.Linq;

namespace _08.CollectionHierarchy
{
    public class MyList : IAddCollection, IRemoveCollection, IUsed
    {
        private readonly List<string> items;

        public MyList()
        {
            this.items = new List<string>();
        }

        public int Used => this.items.Count;

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
            if (this.items != null && this.items.Count != 0)
            {
                int index = 0;
                string item = this.items[index];
                this.items.RemoveAt(index);
                return item;
            }
            return null;
        }
    }
}
