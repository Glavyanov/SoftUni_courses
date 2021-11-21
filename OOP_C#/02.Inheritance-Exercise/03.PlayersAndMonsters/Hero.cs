namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        public Hero(string username, int level)
        {
            this.UserName = username;
            this.Level = level;
        }

        public string UserName { get; set; }

        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}";
        }
    }
}
