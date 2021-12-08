using _07.MilitaryElite.Soldiers;
using System.Collections.Generic;

namespace _07.MilitaryElite.Models
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<ISoldier> Privates { get; set; }
    }
}
