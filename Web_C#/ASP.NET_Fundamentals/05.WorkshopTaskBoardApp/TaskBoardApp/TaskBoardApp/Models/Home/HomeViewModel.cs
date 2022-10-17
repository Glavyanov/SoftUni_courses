namespace TaskBoardApp.Models.Home
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; init; }

        public List<HomeBoardModel> BoardsWithTasksCount { get; init; } = new List<HomeBoardModel>();

        public int UserTasksCount { get; init; }
    }
}
