using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public HomeController(TaskBoardAppDbContext _data)
        {
            data = _data;
        }
    
        public async Task<IActionResult> Index()
        {
            var taskBoards = await this.data.Boards
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();

            var taskCounts = new List<HomeBoardModel>();
            foreach (var boardName in taskBoards)
            {
                var taskInBoard = await this.data.Tasks.Where(t => t.Board.Name == boardName).CountAsync();
                taskCounts.Add(item: new()
                {
                    BoardName = boardName,
                    TasksCount = taskInBoard
                });
            }

            var userTasksCount = -1;

            if (this.User?.Identity?.IsAuthenticated?? false)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                userTasksCount = await this.data.Tasks.Where(t => t.OwnerId == currentUserId).CountAsync();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = await this.data.Tasks.CountAsync(),
                BoardsWithTasksCount = taskCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}