using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class DestinationMapper
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(=|\/)(?<name>[A-Z][A-Za-z]{2,})\1");
            MatchCollection matches = regex.Matches(input);
            Console.WriteLine("Destinations: {0}", string.Join(", ", matches.Select(x => x.Groups["name"].Value)));
            int travelPoints = 0;
            foreach (Match item in matches)
            {
                travelPoints += item.Groups["name"].Value.Length;
            }
            Console.WriteLine("Travel Points: {0}", travelPoints);
        }
    }
}
