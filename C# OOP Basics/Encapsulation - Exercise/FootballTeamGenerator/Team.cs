namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Rating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Round(this.players.Select(p => p.CalculateOveralStats()).Sum() / (double)this.players.Count);
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            bool IsPlayerValid = this.players.Any(p => p.Name == playerName);
            if (IsPlayerValid == false)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            var player = this.players.Where(p => p.Name == playerName).First();

            this.players.Remove(player);
        }
    }
}