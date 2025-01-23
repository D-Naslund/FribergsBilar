using System.Diagnostics;
using FribergsBilar.Models;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
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
            var loggedinString = Request.Cookies["loggedIn"];
            if (loggedinString != null)
            {
                ViewBag.loggedin = loggedinString;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
