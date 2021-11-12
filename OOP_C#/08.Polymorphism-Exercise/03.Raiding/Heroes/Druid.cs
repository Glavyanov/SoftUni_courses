using _03.Raiding.Models;

namespace _03.Raiding.Heroes
{
    public class Druid : BaseHero
    {
        private const int PowerDruid = 80;
        public Druid(string name) 
            : base(name, PowerDruid)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }

}
