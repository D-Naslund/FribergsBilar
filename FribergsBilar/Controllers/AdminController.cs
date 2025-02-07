using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Services;
using FribergsBilar.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("isAdmin", "False");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentAdmin = await adminService.LoginAdminAsync(admin);
                    if (currentAdmin != null)
                    {
                        HttpContext.Session.SetString("isAdmin", "True");
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        TempData["AdminFailureLoginMessage"] = "Login Misslyckades \n Vänligen Försök igen!";
                    }

                }
                HttpContext.Session.SetString("isAdmin", "False");
                return View();
            }
            catch
            {
                return View();
            }
        }

        [AdminAuthorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        [AdminAuthorize]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        [AdminAuthorize]
        public ActionResult Cars()
        {
            return View(adminService.GetAllCars());
        }
        [AdminAuthorize]
        public ActionResult Users()
        {
            return View(adminService.GetAllUsers());
        }
        [AdminAuthorize]
        public ActionResult Bookings()
        {
            return View(adminService.GetAllBookings());
        }

        
    }
}
