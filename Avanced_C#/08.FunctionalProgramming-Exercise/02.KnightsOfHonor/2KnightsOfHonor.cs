using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => $"Sir {x}")
                                    .ToList();
            Action<List<string>> namesPrint = array => Console.WriteLine(string.Join(Environment.NewLine, array));
            namesPrint(names);
        }
    }
}
