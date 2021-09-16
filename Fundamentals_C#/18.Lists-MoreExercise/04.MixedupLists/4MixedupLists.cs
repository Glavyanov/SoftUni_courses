using System;
using System.Collections.Generic;
using System.Linq;

namespace _04MixedupLists
{
    class MixedupLists
    {
        static void Main(string[] args)
        {
            List<int> firstSequence = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            List<int> secondSequence = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            List<int> result = new List<int>();
            int minCount = firstSequence.Count > secondSequence.Count ? secondSequence.Count : firstSequence.Count;
            int maxNum = 0;
            int minNum = 0;

            for (int i = 0; i < minCount; i++)
            {
                result.Add(firstSequence[0]);
                result.Add(secondSequence[secondSequence.Count-1]);
                firstSequence.RemoveAt(0);
                secondSequence.RemoveAt(secondSequence.Count - 1);

            }
            if (firstSequence.Count != 0)
            {
                maxNum = Math.Max(firstSequence[0], firstSequence[1]);
                minNum = Math.Min(firstSequence[0], firstSequence[1]);

            }
            else
            {
                maxNum = Math.Max(secondSequence[0], secondSequence[1]);
                minNum = Math.Min(secondSequence[0], secondSequence[1]);

            }
            List<int> filter = new List<int>();
            foreach (var item in result)
            {
                if (item < maxNum && item > minNum)
                {
                    filter.Add(item);
                }

            }
            filter.Sort();
            Console.WriteLine(string.Join(" ", filter));
        }
    }
}
