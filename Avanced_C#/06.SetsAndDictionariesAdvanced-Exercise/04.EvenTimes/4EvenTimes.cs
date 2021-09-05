using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> occurence = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (!occurence.ContainsKey(input))
                {
                    occurence.Add(input, 0);
                }
                occurence[input]++;
            }
            Console.WriteLine(string.Join("", occurence.Where(x => x.Value % 2 == 0).Select(x => x.Key)));
        }
    }
}
