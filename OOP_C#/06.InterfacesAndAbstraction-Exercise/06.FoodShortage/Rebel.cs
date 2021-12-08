namespace _06.FoodShortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
