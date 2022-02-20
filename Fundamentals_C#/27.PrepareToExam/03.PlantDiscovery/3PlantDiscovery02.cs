using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Plant
    {

        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
    }
    class PlantDiscovery
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = new Dictionary<string, Plant>();
            for (int i = 0; i < n; i++)
            {
                string[] initial = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = initial[0];
                int rarity = int.Parse(initial[1]);
                Plant plant = new Plant()
                {
                    Rarity = rarity,
                    Rating = new List<double>()
                };
                if (!plants.ContainsKey(name))
                {
                    plants.Add(name, plant);

                }
                plants[name] = plant;
            }
            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] cmdArgs = command.Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Rate")
                {
                    string plantToRate = cmdArgs[1];
                    if (plants.ContainsKey(plantToRate))
                    {
                        double rating = double.Parse(cmdArgs[2]);
                        plants[plantToRate].Rating.Add(rating);

                    }
                    else
                    {
                        Console.WriteLine("error");

                    }


                }
                else if (action == "Update")
                {
                    string plantToUpdate = cmdArgs[1];
                    if (plants.ContainsKey(plantToUpdate))
                    {
                        int rarityUpdate = int.Parse(cmdArgs[2]);
                        plants[plantToUpdate].Rarity = rarityUpdate;

                    }
                    else
                    {
                        Console.WriteLine("error");

                    }

                }
                else if (action == "Reset")
                {
                    string plantResetRating = cmdArgs[1];
                    if (plants.ContainsKey(plantResetRating))
                    {
                        plants[plantResetRating].Rating = new List<double>();

                    }
                    else
                    {
                        Console.WriteLine("error");

                    }
                }
                else
                {
                    Console.WriteLine("error");
                }

                command = Console.ReadLine();
            }
            foreach (var item in plants)
            {
                if (item.Value.Rating.Count == 0)
                {
                    item.Value.Rating.Add(0);
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating.Average()))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Rating.Average():F2}");
            }

        }
    }
}
