using System.Diagnostics;
using FribergsBilar.Data;
using FribergsBilar.Models;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICar carRepository;

        public HomeController(ILogger<HomeController> logger, ICar carRepository)
        {
            _logger = logger;
            this.carRepository = carRepository;
        }

        public IActionResult Index()
        {
            ViewData["loggedIn"] = HttpContext.Session.GetString("CurrentEmail");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
