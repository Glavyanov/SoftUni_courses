using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> players;

        private string name;

        public Team(string name)
        {
            Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value; 
            }
        }

        public int Rating => GetStatOfAllPlayers();

        private int GetStatOfAllPlayers()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Round((this.players.Select(p => p.Stat).Sum()) / (double)this.players.Count);
        }

        public void AddPlayer(Player player)
        {
            if (this.players != null)
            {
                this.players.Add(player);
            }
        }

        public void RemovePlayer(string name)
        {
            if (this.players != null && this.players.Any(p => p.Name == name))
            {
                Player player = this.players.FirstOrDefault(p => p.Name == name);
                this.players.Remove(player);
            }
            else if (!this.players.Any(p => p.Name == name))
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }
            
        }
    }
}
