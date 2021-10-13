using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class PokemonTrainer
    {
        public static void Main(string[] args)
        {
            string tournament = Console.ReadLine();
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while (tournament != "Tournament")
            {
                string[] assign = tournament.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = assign[0];
                string pokemonName = assign[1];
                string pokemonElement = assign[2];
                int pokemonHealth = int.Parse(assign[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                }
                trainers[trainerName].Pokemon.Add(pokemon);
                tournament = Console.ReadLine();
            }
            string end = Console.ReadLine();
            while (end != "End")
            {
                if (trainers.Values.Any(x => x.Pokemon.Any(x=> x.Element == end)))
                {
                    foreach (var (name, trainer) in trainers)
                    {
                        if (trainer.Pokemon.Any(x => x.Element == end))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Pokemon.Count; i++)
                            {
                                trainer.Pokemon[i].Health -= 10;
                                if (trainer.Pokemon[i].Health <= 0)
                                {
                                    trainer.Pokemon.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var (name, trainer) in trainers)
                    {
                        for (int i = 0; i < trainer.Pokemon.Count; i++)
                        {
                            trainer.Pokemon[i].Health -= 10;
                            if (trainer.Pokemon[i].Health <= 0)
                            {
                                trainer.Pokemon.RemoveAt(i);
                                i--;
                            }
                        }

                    }
                }

                 end = Console.ReadLine();
            }
             trainers.OrderByDescending(x => x.Value.Badges)
                               .ToList()
                               .ForEach(x => Console.WriteLine($"{x.Key} {x.Value.Badges} {x.Value.Pokemon.Count}"));
        }
    }
}
