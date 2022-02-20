using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class MirrorWords
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(@|#)(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1");
            MatchCollection mathes = regex.Matches(input);
            List<string> mirrorWords = new List<string>();
            foreach (Match item in mathes)
            {
                string wordFirst = item.Groups["first"].Value;
                string wordSecond = item.Groups["second"].Value;
                wordSecond = string.Join("", wordSecond.Reverse());
                if (wordFirst == wordSecond)
                {
                    mirrorWords.Add(wordFirst);
                    mirrorWords.Add(item.Groups["second"].Value);
                }

            }
            if (mathes.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{mathes.Count} word pairs found!");

            }
            if (mirrorWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                for (int i = 1; i < mirrorWords.Count; i += 2)
                {
                    string print = $"{mirrorWords[i - 1]} <=> {mirrorWords[i]}";
                    if (i == mirrorWords.Count - 1)
                    {
                        Console.Write(print);

                    }
                    else
                    {
                        Console.Write($"{print}, ");

                    }
                }
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }

            
        }
    }
}
