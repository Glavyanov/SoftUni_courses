using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class MatchDates
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MatchCollection validDate = Regex.Matches(input, @"\b(?<day>[0-9]{2})(?<separator>[-\/.])(?<month>[A-Z][a-z]{2})(\k<separator>)(?<year>[0-9]{4})\b");
            
            foreach (Match item in validDate)
            {
                var day = item.Groups["day"].Value;
                var month = item.Groups["month"].Value;
                var year = item.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");

            }

        }
    }
}
