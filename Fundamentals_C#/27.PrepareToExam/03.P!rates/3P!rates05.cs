using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.P_rates
{
    class City
    {
        public City()
        {

        }
        public int Population { get; set; }
        public int Gold { get; set; }

    }
    class Pirates
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, City> map = new Dictionary<string, City>();
            while (input != "Sail")
            {
                string[] command = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                int polulation = int.Parse(command[1]);
                int gold = int.Parse(command[2]);
                if (!map.ContainsKey(name))
                {
                    City city = new City()
                    {
                        Population = polulation,
                        Gold = gold
                    };
                    map.Add(name, city);
                }
                else
                {
                    map[name].Population += polulation;
                    map[name].Gold += gold;
                }
                
                input = Console.ReadLine();
            }
            string action = Console.ReadLine();
            while (action != "End")
            {
                string[] actionArgs = action.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = actionArgs[0];
                string city = actionArgs[1];
                if (command == "Plunder")
                {
                    int people = int.Parse(actionArgs[2]);
                    int gold = int.Parse(actionArgs[3]);
                    if (map.ContainsKey(city))
                    {
                        map[city].Population -= people;
                        map[city].Gold -= gold;
                        Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");
                    }
                    if (map[city].Population <= 0 || map[city].Gold <= 0)
                    {
                        map.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }

                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(actionArgs[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        map[city].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {map[city].Gold} gold.");
                    }

                }

                action = Console.ReadLine();
            }
            if (map.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {map.Count} wealthy settlements to go to:");
                foreach (var item in map.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
                }

            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
