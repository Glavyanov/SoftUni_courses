using _03.Raiding.HeroesFactory;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class Raiding
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            HeroFactory factory;
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    factory = new Factory(name, type);

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                    continue;
                }
                var hero = factory.CreateBaseHero();
                heroes.Add(hero);

            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroPower = heroes.Select(h => h.Power).Sum();
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            Console.WriteLine(heroPower >= bossPower ? "Victory!" : "Defeat...");

        }
    }
}
