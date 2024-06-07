using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;
using System.Diagnostics;

namespace StudentApplication.Controllers
{
    public class HomeController : Controller
    {
        private TestService _testService;
        public HomeController(TestService testService)
        {
            this._testService = testService;
        }
        public IActionResult Index()
        {
            _testService.IsSystemReady();
            return View();
        }

    }
}