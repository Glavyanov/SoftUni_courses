namespace _05.BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public string BirthDate { get; private set; }

    }
}
