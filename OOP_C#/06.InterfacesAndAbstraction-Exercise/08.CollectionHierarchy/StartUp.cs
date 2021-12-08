using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            IAddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in elements)
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write($"{addCollection.Add(item)} "); 
                            break;
                        case 1:
                            Console.Write($"{addRemoveCollection.Add(item)} ");
                            break;
                        case 2:
                            Console.Write($"{myList.Add(item)} ");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < 1)
                    {
                        Console.Write($"{addRemoveCollection.Remove()} ");
                    }
                    else
                    {
                        Console.Write($"{myList.Remove()} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
