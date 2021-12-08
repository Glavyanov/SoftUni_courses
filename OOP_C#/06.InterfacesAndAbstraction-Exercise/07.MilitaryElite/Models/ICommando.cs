using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public interface ICommando : ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }
    }
}
