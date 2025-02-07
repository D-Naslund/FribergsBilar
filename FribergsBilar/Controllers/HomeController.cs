using System.Diagnostics;
using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;
using FribergsBilar.Services;
using FribergsBilar.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService carService;

        public HomeController(ILogger<HomeController> logger, ICarService carService )
        {
            _logger = logger;
            this.carService = carService;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("isAdmin") != null)
            {
                HttpContext.Session.Clear();
            }
            ViewData["loggedIn"] = HttpContext.Session.GetString("CurrentEmail");
            return View();
        }

        public ActionResult Cars()
        {
            ViewData["loggedIn"] = HttpContext.Session.GetString("CurrentEmail");
            var carsList = carService.GetCarList();
            return View(carsList);
        }

        [HttpPost]
        public ActionResult Cars(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetInt32("BookingInProcess", id);
                    if (HttpContext.Session.GetInt32("CurrentId") == null)
                    {
                        return RedirectToAction("Login", "User");
                    }
                    else
                    {
                        return RedirectToAction("Date", "Booking");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
