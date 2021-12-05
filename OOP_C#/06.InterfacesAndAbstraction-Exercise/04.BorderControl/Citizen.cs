namespace _04.BorderControl
{
    public class Citizen : IPerson
    {
        public Citizen( string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}
