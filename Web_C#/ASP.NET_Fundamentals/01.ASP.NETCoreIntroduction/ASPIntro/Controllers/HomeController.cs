using ASPIntro.Contracts;
using ASPIntro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPIntro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public HomeController(
            ILogger<HomeController> logger,
            ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Test()
        {
            TestModel model = new();

            return View(model);
        }

        [HttpPost]
        public IActionResult Test(TestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string product = _testService.GetProduct(model);

            return View("TestView", model);
        }

        [Route("/Home/Edit/{id}")]
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}