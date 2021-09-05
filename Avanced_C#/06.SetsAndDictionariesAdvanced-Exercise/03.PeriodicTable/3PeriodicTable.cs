using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] currentElements = Console.ReadLine()
                                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in currentElements)
                {
                    elements.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
