using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Tasks;
using TaskBoardApp.Data.Entities;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TasksController(TaskBoardAppDbContext _data)
        {
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel model = new()
            {
                Boards = await GetBoards()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create), model);
            }
            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            Data.Entities.Task task = new()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = currentUserId
            };

            await this.data.Tasks.AddAsync(task);
            await this.data.SaveChangesAsync();

            return RedirectToAction("Index", "Boards");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private async Task<IEnumerable<TaskBoardModel>> GetBoards() => 
                await this.data.Boards
                .AsNoTracking()
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToListAsync();
    }
}
