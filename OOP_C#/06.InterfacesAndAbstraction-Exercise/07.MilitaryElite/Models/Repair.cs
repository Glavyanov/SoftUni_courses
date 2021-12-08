namespace _07.MilitaryElite.Models
{
    public class Repair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.HoursWorked = hoursWorked;
            this.PartName = partName;
        }

        public int HoursWorked { get; set; }

        public string PartName { get; set; }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
