using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class RecordUniqueNames
    {
        static void Main(string[] args)
        {

            var set = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
