using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] setsSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray();
            HashSet<string> first = new HashSet<string>();
            HashSet<string> second = new HashSet<string>();
            for (int i = 0; i < setsSize[0] + setsSize[1]; i++)
            {
                bool assign = i < setsSize[0] ? first.Add(Console.ReadLine()) : second.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join(' ', first.Intersect(second))); 
        }
    }
}
