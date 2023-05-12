using ErrorHandlingApp.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingApp.Controllers
{
    [CustomHandleExceptionFilterAttriubute(ErrorPage = "Hata2")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Veri tabanına bağlanırken bir hata meydana geldi");
            return View();
        }
        public IActionResult Hata2()
        {
            return View();
        }
    }
}
