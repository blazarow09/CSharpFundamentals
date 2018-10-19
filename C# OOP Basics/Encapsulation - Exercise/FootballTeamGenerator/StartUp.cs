namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var teams = new List<Team>();

            var tokens = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            while (tokens[0] != "END")
            {
                switch (tokens[0])
                {
                    case "Team":
                        teams.Add(new Team(tokens[1]));
                        break;

                    case "Add":
                        Team team;

                        var doesTheTeamExists = teams.Any(t => t.Name == tokens[1]);

                        if (doesTheTeamExists == false)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                team = teams.Where(t => t.Name == tokens[1]).First();
                                var player = new Player(tokens[2],
                                    int.Parse(tokens[3]),
                                    int.Parse(tokens[4]),
                                    int.Parse(tokens[5]),
                                    int.Parse(tokens[6]),
                                    int.Parse(tokens[7]));

                                team.AddPlayer(player);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case "Remove":

                        team = teams.Where(t => t.Name == tokens[1]).First();

                        try
                        {
                            team.RemovePlayer(tokens[2]);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Rating":
                        doesTheTeamExists = teams.Any(t => t.Name == tokens[1]);

                        if (doesTheTeamExists == false)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            team = teams.Where(t => t.Name == tokens[1]).First();

                            Console.WriteLine($"{team.Name} - {team.Rating()}");
                        }
                        break;
                }

                tokens = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}