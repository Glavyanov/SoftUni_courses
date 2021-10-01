using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string pattern = @"(?<text>[^0-9]+)(?<num>[0-9]+)";
            MatchCollection rageQuits = Regex.Matches(input, pattern);
            StringBuilder uniqueSymbols = new StringBuilder();
            foreach (Match item in rageQuits)
            {
                if (int.Parse(item.Groups["num"].Value) > 0)
                {
                    uniqueSymbols.Append(item.Groups["text"].Value);
                }
            }
            for (int i = uniqueSymbols.Length - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (uniqueSymbols[i] == uniqueSymbols[j])
                    {
                        uniqueSymbols.Remove(i, 1);
                        break;
                    }
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Length}");
            foreach (Match item in rageQuits)
            {
                string letter = item.Groups["text"].Value;
                int digit = int.Parse(item.Groups["num"].Value);
                for (int i = 0; i < digit; i++)
                {
                    Console.Write(letter);
                }

            }

        }
    }
}
