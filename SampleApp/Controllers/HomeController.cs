using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SampleApp.Models;

using System.Diagnostics;

namespace SampleApp.Controllers
{

    //[Authorize(Roles = "Admin")]  //This is for the whole 
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


        [Authorize(Roles = "Admin")]// Only for privacy
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
