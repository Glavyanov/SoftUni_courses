using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.roster != null && this.roster.Count < Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.roster != null && this.roster.Any(p => p.Name == name))
            {
                Player player = this.roster.First(p => p.Name == name);
                this.roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (this.roster != null && this.roster.Any(p => p.Name == name))
            {
                Player player = this.roster.First(p => p.Name == name);
                if (player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.First(p => p.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            if (this.roster != null)
            {
                Player[] kick = this.roster.Where(p => p.Class == @class).ToArray();
                foreach (var item in kick)
                {
                    this.roster.Remove(item);
                }
                return kick;
            }
            return null;
        }

        public string Report()
        {
            return $"Players in the guild: {this.Name}{Environment.NewLine}{string.Join(Environment.NewLine, this.roster)}";
        }

    }
}
