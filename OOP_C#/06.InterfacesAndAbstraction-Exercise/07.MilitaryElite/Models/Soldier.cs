namespace _07.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        
        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get ; set ; }
        public string LastName { get  ; set ; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
