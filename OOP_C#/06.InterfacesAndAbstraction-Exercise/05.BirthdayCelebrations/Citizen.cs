namespace _05.BirthdayCelebrations
{
    public class Citizen : IPerson , IBirthable
    {
        public Citizen( string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string BirthDate { get; private set; }
    }
}
