namespace JokeApp.Models
{
    public class Joke
    {
        public int Id { get; set; }

        public string Question { get; set; } = null!;

        public string Answer { get; set; } = null!;
    }
}
