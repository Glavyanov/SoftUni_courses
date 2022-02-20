using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
           SortedDictionary<int, int> occurence = new SortedDictionary<int, int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (!occurence.ContainsKey(nums[i]))
                {
                    occurence[nums[i]] = 0;
                }
                occurence[nums[i]]++;

            }

            foreach (var item in occurence)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
