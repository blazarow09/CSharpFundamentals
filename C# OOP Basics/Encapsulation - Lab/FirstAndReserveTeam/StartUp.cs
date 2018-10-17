using System;
using System.Collections.Generic;

namespace ValidationOfData
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var countLines = int.Parse(Console.ReadLine());

            var players = new List<Person>();

            for (int i = 0; i < countLines; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var player = new Person(
                    tokens[0],
                    int.Parse(tokens[2]),
                    decimal.Parse(tokens[3]));

                players.Add(player);
            }

            var team = new Team("SoftUni");
            foreach (var p in players)
            {
                team.AddPlayer(p);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}