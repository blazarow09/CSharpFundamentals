using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string lines;
            while ((lines = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = lines.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (trainers.Any(t => t.Name == trainerName) == false)
                {
                    Trainer trainerInfo = new Trainer(trainerName);
                    trainers.Add(trainerInfo);
                }

                Trainer trainer = trainers.First(t => t.Name == trainerName);
                Pokemon pokemonInfo = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.AddPokemon(pokemonInfo);
            }

            while ((lines = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    string element = lines;
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.IncreaseBadges();
                    }
                    else
                    {
                        trainer.ReducePokemonsHealth();
                        trainer.RemoveDead();
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}