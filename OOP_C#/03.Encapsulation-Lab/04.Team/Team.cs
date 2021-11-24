using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.FirstTeam = new List<Person>();
            this.ReserveTeam = new List<Person>();
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
            private set { reserveTeam = value.ToList(); }
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
            private set { firstTeam = value.ToList(); }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

    }
}
