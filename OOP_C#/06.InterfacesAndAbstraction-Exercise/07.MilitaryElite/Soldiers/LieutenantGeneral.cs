using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Soldiers
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<ISoldier>();
        }

        public List<ISoldier> Privates { get ; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.Privates)
            {
                sb.AppendLine($"  {item}");
            }
            
            return this.Privates.Count > 0 ? base.ToString() + $"{Environment.NewLine}Privates:{Environment.NewLine}{sb.ToString().TrimEnd()}" : base.ToString() + $"{Environment.NewLine}Privates:";
        }
    }
}
