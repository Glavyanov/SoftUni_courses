namespace TaskBoardApp.Models.Tasks
{
    public class TaskViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Description { get; init; } = null!;

        public string Owner { get; init; } = null!;
    }
}
