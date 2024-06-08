using Microsoft.AspNetCore.Mvc;

namespace StudentApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
