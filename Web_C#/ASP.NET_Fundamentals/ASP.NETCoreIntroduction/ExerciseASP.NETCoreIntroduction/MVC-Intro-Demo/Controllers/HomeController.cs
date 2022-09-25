using Microsoft.AspNetCore.Mvc;
using MVC_Intro_Demo.Models;
using System.Diagnostics;

namespace MVC_Intro_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello World!";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app";

            return View();
        }


        [HttpGet]
        public IActionResult Numbers()
        {
            ViewBag.Message = "Nums 1 ... 50";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}