using HangFire.Web.BackgroundJobs;
using HangFire.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangFire.Web.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            //Üye kayıt işlemi bu methodda gerçekleşiyor.
            //Yeni üye olan kullanıcınıın user ID al
            FireAndForgetJobs.EmailSendToUserJob("capacitorkondansator@gmail.com", "Sitemize Hoşgeldiniz.");
            return View();
        }

        public IActionResult PictureSave()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName = String.Empty;
            if (picture != null && picture.Length > 0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFileName);

                using FileStream stream = new(path,FileMode.Create);
                await picture.CopyToAsync(stream);
            }
            string jobId = BackgroundJobs.DelayedJobs.AddWaterMarkJob(newFileName,"www.mysite.com");

            return View();
        }
    }
}