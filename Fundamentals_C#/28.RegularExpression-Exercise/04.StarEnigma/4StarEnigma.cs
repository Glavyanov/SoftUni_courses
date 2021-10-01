using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            int countMessage = int.Parse(Console.ReadLine());
            string pattern = @"[STARstar]";
            string valid = @"@(?<planet>[A-Za-z]+)[^@:!\->]*:(?<population>\d+)[^@:!\->]*!(?<type>[A|D])![^@:!\->]*\->(?<soldier>\d+)";
            
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            for (int i = 0; i < countMessage; i++)
            {
                string encrypted = Console.ReadLine();
                int countMatches = Regex.Matches(encrypted, pattern).Count;
                StringBuilder decrypt = new StringBuilder();
                for (int j = 0; j < encrypted.Length; j++)
                {
                    char current = encrypted[j];
                    current -= (char)countMatches;
                    decrypt.Append(current);
                }
                Match match = Regex.Match(decrypt.ToString(), valid);
                if (match.Success)
                {
                    if (match.Groups["type"].Value == "A")
                    {
                        string planet = match.Groups["planet"].Value;
                        attacked.Add(planet);
                    }
                    else
                    {
                        string planet = match.Groups["planet"].Value;
                        destroyed.Add(planet);
                    }
                    
                }

            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            if (attacked.Count > 0)
            {
                attacked.Sort();
                for (int i = 0; i < attacked.Count; i++)
                {
                    Console.WriteLine($"-> {attacked[i]}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            if (destroyed.Count > 0)
            {
                destroyed.Sort();
                for (int i = 0; i < destroyed.Count; i++)
                {
                    Console.WriteLine($"-> {destroyed[i]}");
                }
            }

        }
    }
}
