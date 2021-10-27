using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskOne
{
    class FoodFinder
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, List<char>>()
            {
                {"pear", new List<char>(){'p','e','a','r' } },
                {"flour",  new List<char>(){'f','l','o','u','r' } },
                { "pork", new List<char>(){'p','o','r','k' } },
                {"olive", new List<char>(){'o','l','i','v','e' } }
            };
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            while (consonants.Count != 0)
            {
                char currVowel = vowels.Dequeue();
                char currConson = consonants.Pop();
                vowels.Enqueue(currVowel);

                for (int i = 0; i < words.Count; i++)
                {
                    var item = words.ElementAt(i);
                    var itemKey = item.Key;

                    for (int j = 0; j < itemKey.Length; j++)
                    {
                        char curr = itemKey[j];
                        if (currVowel == curr && words[itemKey].Any(w => w == curr))
                        {
                            words[itemKey].Remove(curr);
                        }
                        if (currConson == curr && words[itemKey].Any(w => w == curr))
                        {
                            words[itemKey].Remove(curr);
                        }
                    }
                }
            }
            var foundWords = words.Where(w => w.Value.Count < 1).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine($"Words found: {foundWords.Count}");
            foreach (var item in foundWords)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
