namespace _05.BirthdayCelebrations
{
    public class Robot : IPerson
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Id { get; private set; }

        public string Model { get; private set; }

    }
}
