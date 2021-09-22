using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> occurence = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (occurence.ContainsKey(words[i].ToLower()))
                {
                    occurence[words[i].ToLower()]++;
                }
                else
                {
                    occurence.Add(words[i].ToLower(), 1);
                }

            }
            Console.WriteLine(string.Join(' ', occurence.Where(x => x.Value % 2 != 0).Select(x => x.Key)));

        }
    }
}
