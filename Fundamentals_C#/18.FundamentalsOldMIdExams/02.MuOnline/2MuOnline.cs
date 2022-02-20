using System;
using System.Linq;
using System.Collections.Generic;


namespace _02.MuOnline
{
    class MuOnline
    {
        static void Main(string[] args)
        {

            int health = 100;
            int bitcoins = 0;
            List<string> rooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < rooms.Count; i++)
            {
                string[] command = rooms[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                if (action == "potion")
                {
                    int potion = int.Parse(command[1]);
                    health += potion;
                    int healed = potion;
                    if (health > 100)
                    {
                        healed = 100 - (health - potion);
                        health = 100;
                    }
                    Console.WriteLine($"You healed for {healed} hp.");
                    Console.WriteLine($"Current health: {health} hp.");

                }
                else if (action == "chest")
                {
                    int bitcoin = int.Parse(command[1]);
                    bitcoins += bitcoin;
                    Console.WriteLine("You found {0} bitcoins.", bitcoin);

                }
                else
                {
                    int attack = int.Parse(command[1]);
                    health -= attack;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {action}.");

                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {action}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }

                }

            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}
