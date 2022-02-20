using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class AdAstra
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(#|\|)(?<name>[A-Za-z ]+)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[1-9]([0-9]{1,3})?)\1");
            MatchCollection matches = regex.Matches(input);
            int sum = 0;
            foreach (Match item in matches)
            {
                sum += int.Parse(item.Groups["calories"].Value);
            }
            Console.WriteLine($"You have food to last you for: {sum/2000} days!");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["name"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }
        }
    }
}
