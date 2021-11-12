using _03.Raiding.Heroes;
using _03.Raiding.Models;
using System;

namespace _03.Raiding.HeroesFactory
{
    public sealed class Factory : HeroFactory
    {
        private readonly string name;
        private string type;

        public Factory(string name, string type)
        {
            this.name = name;
            this.Type = type;
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (value is "Warrior" || value is "Druid" || value is "Paladin" || value is "Rogue")
                {
                    type = value;
                }
                else
                {
                    throw new FormatException("Invalid hero!");
                }
            }
        }

        public override BaseHero CreateBaseHero()
        {
            BaseHero hero = null;
            if (this.Type != null)
            {
                if (this.Type == "Warrior")
                {
                    hero = new Warrior(this.name);
                }
                else if (this.Type == "Druid")
                {
                    hero = new Druid(this.name);
                }
                else if (this.Type == "Paladin")
                {
                    hero = new Paladin(this.name);

                }
                else if (this.Type == "Rogue")
                {
                    hero = new Rogue(this.name);
                }
                
            }
            return hero;
        }
    }
}
