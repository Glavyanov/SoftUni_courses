using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Tasks;
using TaskBoardApp.Data.Entities;
using System.Globalization;

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
                model.Boards = await GetBoards();
                return View(model);
            }

            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
                return View(model);

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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await this.data.Tasks
                .AsNoTracking()
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.HasValue ? t.CreatedOn.Value.ToString("dd/MM/yyyy HH:mm") : String.Empty,
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName

                }).FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await this.data.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskFormModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await GetBoards()
            };


            return View(taskFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            var task = await this.data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if(!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");

                return View(model);
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await this.data.SaveChangesAsync();

            return RedirectToAction("Index", "Boards");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await this.data.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskViewModel = new TaskViewModel()
            {
                Id = task.Id,
                Description = task.Description,
                Title = task.Title,
            };

            return View(taskViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {

            var task = await this.data.Tasks.FindAsync(model.Id);
            if (task == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            this.data.Tasks.Remove(task);
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
