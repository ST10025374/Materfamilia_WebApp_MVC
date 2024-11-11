using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SampleApp.Models;

using System.Diagnostics;

namespace SampleApp.Controllers
{
    //[Authorize(Roles = "Admin")]  //if uncommented only Admin have access to the home page
    public class HomeController : Controller
    {
        /// <summary>
        /// The logger for the home controller
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Method to initialize the home controller
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Method to get the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Method to get the privacy page
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]// Only for privacy
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Method 
        /// </summary>
        /// <returns></returns>
        public IActionResult MediaAdmin()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Method to get the About page
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Method to get the ContactUs page
        /// </summary>
        /// <returns></returns>
        public IActionResult ContactUs()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Method to get the error page    
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 