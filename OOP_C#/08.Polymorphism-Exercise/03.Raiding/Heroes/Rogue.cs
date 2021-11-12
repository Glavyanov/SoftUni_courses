using _03.Raiding.Models;

namespace _03.Raiding.Heroes
{
    public class Rogue : BaseHero
    {
        private const int PowerRogue = 80;

        public Rogue(string name) 
            : base(name, PowerRogue)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
