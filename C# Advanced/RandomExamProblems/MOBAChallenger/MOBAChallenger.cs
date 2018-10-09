namespace MOBAChallenger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MOBAChallenger
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(new[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var seasonDb = new Dictionary<string, Dictionary<string, int>>();

            while (line[0] != "Season end")
            {
                var firstPlayer = line[0];

                if (line.Count > 2)
                {

                    if (seasonDb.ContainsKey(firstPlayer) == false)
                    {
                        seasonDb[firstPlayer] = new Dictionary<string, int>();
                        seasonDb[firstPlayer].Add(line[1], int.Parse(line[2]));
                    }
                    else if (seasonDb.ContainsKey(firstPlayer) == true)
                    {
                        seasonDb[firstPlayer].Add(line[1], int.Parse(line[2]));
                    }
                }
                else
                {
                    var secondPlayer = line[1];

                    if (seasonDb.ContainsKey(firstPlayer) && seasonDb.ContainsKey(secondPlayer))
                    {
                        BattlePhase(seasonDb, firstPlayer, secondPlayer);
                    }
                }

                line = Console.ReadLine()
                .Split(new[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            Print(seasonDb);
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> seasonDb)
        {
            foreach (var player in seasonDb
            .OrderByDescending(t => t.Value
            .Values
            .Sum())
            .ThenBy(p => p.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var skill in player.Value
                    .OrderByDescending(s => s.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {skill.Key} <::> {skill.Value}");
                }
            }
        }

        private static void BattlePhase(Dictionary<string, Dictionary<string, int>> seasonDb, string firstPlayer, string secondPlayer)
        {
            var list = seasonDb[firstPlayer].Keys.ToList();
            var playerToRemove = "";
            foreach (var skill in list)
            {
                if (seasonDb[secondPlayer].ContainsKey(skill))
                {
                    if (seasonDb[firstPlayer].Values.Sum() < seasonDb[secondPlayer].Values.Sum())
                    {
                        playerToRemove = firstPlayer;
                    }
                    else if (seasonDb[firstPlayer].Values.Sum() > seasonDb[secondPlayer].Values.Sum())
                    {
                        playerToRemove = secondPlayer;
                    }
                }
            }
            seasonDb.Remove(playerToRemove);
        }
    }
}
