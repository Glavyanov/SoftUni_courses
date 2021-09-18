using System;
using System.Linq;
using System.Collections.Generic;

namespace _01RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Random random = new Random();
            for (int i = 0; i < words.Count; i++)
            {
                int swapPosition = random.Next(words.Count);
                string current = words[i];
                words[i] = words[swapPosition];
                words[swapPosition] = current;
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
