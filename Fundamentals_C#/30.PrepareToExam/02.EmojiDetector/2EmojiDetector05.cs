using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class EmojiDetector
    {
        static void Main(string[] args)
        {
            Regex pattern =new Regex( @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1");
            string input = Console.ReadLine();
            MatchCollection matches = pattern.Matches(input);
            string replaced = pattern.Replace(input, "**");
            long coolness = 1;
            for (int i = 0; i < replaced.Length; i++)
            {
                    char curr = replaced[i];
                if (char.IsDigit(replaced[i]))
                {
                    int current = int.Parse(replaced[i].ToString());
                    coolness *= current;
                }
            }
            Console.WriteLine($"Cool threshold: {coolness}");
            List<string> valid = new List<string>();
            foreach (Match item in matches)
            {
                int currentCoolness = 0;
                for (int i = 0; i < item.Groups["emoji"].Value.Length; i++)
                {
                    char curr = item.Groups["emoji"].Value[i];
                    currentCoolness += curr;

                }
                if (currentCoolness > coolness)
                {
                    string itemToAdd = item.Value;
                    valid.Add(itemToAdd);
                }
            }
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join("\n",valid));
            
        }
    }
}
