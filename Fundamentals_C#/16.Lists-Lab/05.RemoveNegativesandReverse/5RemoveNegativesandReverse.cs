﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05RemoveNegativesandReverse
{
    class RemoveNegativesandReverse
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers.RemoveAll(x => x < 0);
            numbers.Reverse();
            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(' ',numbers));
            }
        }
    }
}
