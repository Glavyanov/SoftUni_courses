using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            Random rnd = new Random();
            int index = rnd.Next(0, this.Count - 1);
            string temp = this[index];
            this.RemoveAt(index);
            return temp;
        }
    }
}
