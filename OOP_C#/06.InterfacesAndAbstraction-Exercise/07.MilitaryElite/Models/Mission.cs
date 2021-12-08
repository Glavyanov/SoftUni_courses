namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string name, Status status)
        {
            this.Name = name;
            this.Status = status;
        }

        public string Name { get ; set ; }
        public Status Status { get; set; }

        public override string ToString()
        {
            return $"  Code Name: {this.Name} State: {this.Status}";
        }
    }
}
