using _03.Raiding.Models;

namespace _03.Raiding.Heroes
{
    public class Warrior : BaseHero
    {
        private const int PowerWarrior = 100;

        public Warrior(string name) 
            : base(name, PowerWarrior)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
