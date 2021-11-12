using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person()
        {

        }

        public Person(string name, int year, string town) : this()
        {
            this.Name = name;
            this.Year = year;
            this.Town = town;
        }
        public string Name { get; private set; }

        public int Year { get; private set; }

        public string  Town { get; set; }

        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name) != 0 ? this.Name.CompareTo(other.Name) : this.Year.CompareTo(other.Year) != 0 ? this.Year.CompareTo(other.Year) : this.Town.CompareTo(other.Town) != 0 ? this.Town.CompareTo(other.Town) : this.Town.CompareTo(other.Town); ;
        }
    }
}
