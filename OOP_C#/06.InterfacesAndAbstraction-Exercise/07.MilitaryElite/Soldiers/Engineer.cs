using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace _07.MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier , IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get ; set ; }

        public override string ToString()
        {
            return this.Repairs.Count > 0 ? base.ToString() + $"{Environment.NewLine}Repairs:{Environment.NewLine}{string.Join(Environment.NewLine, this.Repairs)}" : base.ToString() + $"{Environment.NewLine}Repairs:";
        }
    }
}
