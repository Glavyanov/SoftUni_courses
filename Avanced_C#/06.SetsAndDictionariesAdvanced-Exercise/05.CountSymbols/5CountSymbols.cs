using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> occurance = new SortedDictionary<char, int>();

            foreach (var item in input)
            {
                if (!occurance.ContainsKey(item))
                {
                    occurance.Add(item, 0);
                }
                occurance[item]++;
            }
            foreach (var item in occurance)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
