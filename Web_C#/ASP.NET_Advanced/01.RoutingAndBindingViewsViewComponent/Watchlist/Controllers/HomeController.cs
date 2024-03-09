using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Watchlist.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Movies");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Upload() => View();

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFileCollection files) =>
            Json(new { fileCount = files.Count, fileSize = files.Sum(f => f.Length) });
        
    }
}