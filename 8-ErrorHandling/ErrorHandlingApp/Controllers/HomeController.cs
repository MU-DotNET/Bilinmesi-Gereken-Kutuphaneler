using ErrorHandlingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErrorHandlingApp.Controllers
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
            //throw new Exception("Veri tabanına bağlanırken bir hata meydana geldi");

            int value1 = 5;
            int value2 = 0;
            int result = value1 / value2;
            return View();
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