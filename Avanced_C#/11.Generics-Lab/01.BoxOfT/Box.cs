using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public int Count
        {
            get
            {
                return data.Count; // с това изпозваме Count на List-a data, вместо наш собствен който постоянно да променяме в методите.
            }
        }

        public Box()
        {
            data = new List<T>();
            
        }

        public void Add(T element)
        {
            data.Add(element);
            
        }

        public T Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Can not remove from empty collection");
            }

            T result = data.Last();
            data.RemoveAt(data.Count-1);

            return result;
        }
    }
}
