using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesofCodeAndLogicVII
{
    class Hero
    {
        public int HP { get; set; }
        public int MP { get; set; }
    }
    class HeroesofCodeAndLogicVII
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < n; i++)
            {
                string[] heroInitialize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = heroInitialize[0];
                int hitPoints = int.Parse(heroInitialize[1]);
                int manaPoints = int.Parse(heroInitialize[2]);
                Hero hero = new Hero()
                {
                    HP = hitPoints,
                    MP = manaPoints
                };
                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, hero);
                }

            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string name = cmdArgs[1];
                if (action == "CastSpell")
                {
                    int manaPointsNeeded = int.Parse(cmdArgs[2]);
                    string spellName = cmdArgs[3];
                    if (heroes[name].MP >= manaPointsNeeded)
                    {
                        heroes[name].MP -= manaPointsNeeded;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].MP} MP!");

                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }

                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(cmdArgs[2]);
                    string attacker = cmdArgs[3];
                    heroes[name].HP -= damage;
                    if (heroes[name].HP > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }

                }
                else if (action == "Recharge")
                {
                    int amountMana = int.Parse(cmdArgs[2]);
                    int current = heroes[name].MP;
                    heroes[name].MP += amountMana;
                    if (heroes[name].MP > 200)
                    {
                        heroes[name].MP = 200;
                        Console.WriteLine($"{name} recharged for {heroes[name].MP - current} MP!");

                    }
                    else
                    {
                        Console.WriteLine($"{name} recharged for {amountMana} MP!");
                    }
                }
                else if (action == "Heal")
                {
                    int amountHealth = int.Parse(cmdArgs[2]);
                    int current = heroes[name].HP;
                    heroes[name].HP += amountHealth;
                    if (heroes[name].HP > 100)
                    {
                        heroes[name].HP = 100;
                        Console.WriteLine($"{name} healed for {heroes[name].HP - current} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} healed for {amountHealth} HP!");
                    }

                }
                command = Console.ReadLine();

            }
            foreach (var item in heroes.OrderByDescending(x => x.Value.HP).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value.HP}");
                Console.WriteLine($"  MP: {item.Value.MP}");
            }
        }
    }
}
