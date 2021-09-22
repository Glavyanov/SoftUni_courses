using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .OrderByDescending(n => n)
                 .Take(3)
                 .ToArray();

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
