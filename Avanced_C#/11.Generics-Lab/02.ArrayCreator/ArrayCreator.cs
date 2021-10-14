using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item)
        {
            var arr = new T[lenght];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = item;
            }
            return arr;
        }
    }
}
