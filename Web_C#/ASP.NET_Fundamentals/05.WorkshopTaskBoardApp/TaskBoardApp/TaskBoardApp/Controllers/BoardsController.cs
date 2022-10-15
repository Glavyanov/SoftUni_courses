using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Data;

namespace TaskBoardApp.Controllers
{
    public class BoardsController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public BoardsController(TaskBoardAppDbContext _data)
        {
            data = _data;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
