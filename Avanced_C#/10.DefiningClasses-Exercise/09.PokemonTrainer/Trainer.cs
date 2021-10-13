using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer (string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemon = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemon { get; set; }
    }
}
