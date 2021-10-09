using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var locations = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] assign = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (locations.ContainsKey(assign[0]))
                {
                    if (locations[assign[0]].ContainsKey(assign[1]))
                    {
                        locations[assign[0]][assign[1]].Add(assign[2]);
                    }
                    else
                    {
                        locations[assign[0]].Add(assign[1], new List<string>() { assign[2] });
                    }
                }
                else
                {
                    locations.Add(assign[0], new Dictionary<string, List<string>>() { [assign[1]] = new List<string>() { assign[2] } });
                }

            }
            foreach (var location in locations)
            {
                Console.WriteLine($"{location.Key}:");
                foreach (var item in location.Value)
                {
                    Console.WriteLine($"  {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
