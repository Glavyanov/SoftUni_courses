using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> occurrance = new Dictionary<string, int>();
            foreach (var item in input)
            {
                if (!occurrance.ContainsKey(item))
                {
                    occurrance[item] = 1;
                }
                else
                {
                    occurrance[item]++;
                }
            }
            foreach (var item in occurrance)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
