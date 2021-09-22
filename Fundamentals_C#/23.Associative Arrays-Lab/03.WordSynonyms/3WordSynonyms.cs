using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    class WordSynonyms
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!synonyms.ContainsKey(word))
                {
                    synonyms.Add(word, new List<string>());
                    synonyms[word].Add(synonym);

                }
                else
                {
                    synonyms[word].Add(synonym);
                }

            }
            foreach (var item in synonyms)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
