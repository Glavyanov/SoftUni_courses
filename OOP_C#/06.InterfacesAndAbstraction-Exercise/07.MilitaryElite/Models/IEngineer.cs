using System.Collections.Generic;

namespace _07.MilitaryElite.Models
{
    public interface IEngineer :ISpecialisedSoldier
    {
        public List<Repair> Repairs { get; set; }
    }
}
