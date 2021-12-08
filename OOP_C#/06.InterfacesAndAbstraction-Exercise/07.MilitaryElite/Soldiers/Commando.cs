using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace _07.MilitaryElite.Soldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public List<IMission> Missions { get ; set; }

        public override string ToString()
        {
            return this.Missions.Count > 0 ? base.ToString() + $"{Environment.NewLine}Missions:{Environment.NewLine}{string.Join(Environment.NewLine, this.Missions)}" : base.ToString() + $"{Environment.NewLine}Missions:";
        }
    }
}
