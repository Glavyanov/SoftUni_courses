namespace _07.MilitaryElite.Models
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; set; }
    }
}
