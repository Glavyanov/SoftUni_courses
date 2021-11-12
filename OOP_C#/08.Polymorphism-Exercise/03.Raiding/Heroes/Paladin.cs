using _03.Raiding.Models;

namespace _03.Raiding.Heroes
{
    public class Paladin : BaseHero
    {
        private const int PowerPaladin= 100;

        public Paladin(string name) 
            : base(name, PowerPaladin)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";

        }
    }
}
