using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;

namespace Calculator.Controllers
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
            return View();
        }

        [HttpPost]
        public string Calculation([FromBody] string content)
        {
            TextModel model = new TextModel();
            model.TextNumer = new DataTable().Compute(content, null).ToString();
            return model.TextNumer;
        }

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