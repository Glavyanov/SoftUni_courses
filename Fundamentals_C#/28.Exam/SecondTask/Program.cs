using System;
using System.Text.RegularExpressions;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                Regex regex = new Regex(@"!(?<command>[A-Z][a-z]{2,})!:\[(?<text>[A-Za-z]{8,})\]");
                Match match = regex.Match(message);
                if (match.Success)
                {
                    int[] nums = new int[match.Groups["text"].Value.Length];
                    string text = match.Groups["text"].Value;
                    for (int j = 0; j < text.Length; j++)
                    {
                        nums[j] = (int)text[j];

                    }
                    Console.WriteLine($"{match.Groups["command"].Value}: {string.Join(" ",nums)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
