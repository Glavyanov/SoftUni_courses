using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> isLargerOrEqual = (name, sum) => name.Sum(x => x) >= sum;

            Func<List<string>, Func<string, int, bool>, string> desiredName = (allNames, func) => allNames.FirstOrDefault(x => func(x, n));

            Console.WriteLine(desiredName(names, isLargerOrEqual)); 
        }
    }
}
