using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player()
        {
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public Player(string name, string @class) 
            : this()
        {
            Name = name;
            Class = @class;
        }

        public string Name { get; set; }

        public string  Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Player {this.Name}: {this.Class}{Environment.NewLine}Rank: {this.Rank}{Environment.NewLine}Description: {this.Description}";
        }
    }
}
