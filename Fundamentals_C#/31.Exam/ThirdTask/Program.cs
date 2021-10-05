using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdTask
{
    class Soldgier
    {
        public int Health { get; set; }
        public int Energy { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            string command = Console.ReadLine();
            Dictionary<string, Soldgier> soldgiers = new Dictionary<string, Soldgier>();
            while (command != "Results")
            {
                string[] cmdArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Add")
                {
                    string name = cmdArgs[1];
                    int health = int.Parse(cmdArgs[2]);
                    int energy = int.Parse(cmdArgs[3]);
                    Soldgier soldgier = new Soldgier()
                    {
                        Health = health,
                        Energy = energy
                    };
                    if (!soldgiers.ContainsKey(name))
                    {
                        soldgiers.Add(name, soldgier);
                    }
                    else
                    {
                        soldgiers[name].Health += health;
                    }

                }
                else if (action == "Attack")
                {
                    string attackerName = cmdArgs[1];
                    string defenderName = cmdArgs[2];
                    int damage = int.Parse(cmdArgs[3]);
                    if (soldgiers.ContainsKey(attackerName) && soldgiers.ContainsKey(defenderName))
                    {
                        soldgiers[defenderName].Health -= damage;
                        if (soldgiers[defenderName].Health <= 0)
                        {
                            Console.WriteLine($"{defenderName} was disqualified!");
                            soldgiers.Remove(defenderName);
                        }
                        soldgiers[attackerName].Energy -= 1;
                        if (soldgiers[attackerName].Energy <= 0)
                        {
                            Console.WriteLine($"{attackerName} was disqualified!");
                            soldgiers.Remove(attackerName);
                        }

                    }

                }
                else if (action == "Delete")
                {
                    string userName = cmdArgs[1];
                    if (soldgiers.ContainsKey(userName))
                    {
                        soldgiers.Remove(userName);
                    }
                    else if (userName == "All")
                    {
                        soldgiers = new Dictionary<string, Soldgier>();
                    }

                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"People count: {soldgiers.Count}");
            foreach (var item in soldgiers.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value.Health} - {item.Value.Energy}");
            }
        }
    }
}
