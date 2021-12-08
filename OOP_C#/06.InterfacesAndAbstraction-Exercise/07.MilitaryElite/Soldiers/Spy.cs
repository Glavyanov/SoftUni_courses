using _07.MilitaryElite.Models;
using System;

namespace _07.MilitaryElite.Soldiers
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get ; set ; }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Code Number: {this.CodeNumber}";
        }
    }
}
