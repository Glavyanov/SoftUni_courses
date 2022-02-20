using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class CountCharsInAString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var countChars = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!countChars.ContainsKey(input[i]) && input[i] != ' ')
                {
                    countChars.Add(input[i], 1);
                }
                else if(input[i] != ' ')
                {
                    countChars[input[i]]++;
                }
            }
            foreach (var (key, value) in countChars)
            {
                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
