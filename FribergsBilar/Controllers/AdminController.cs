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
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Admin admin)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var currentAdmin = await adminService.LoginAdminAsync(admin);
                    if (currentAdmin != null)
                    {
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        TempData["AdminFailureLoginMessage"] = "Login Misslyckades \n Vänligen Försök igen!";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Cars()
        {
            return View(adminService.GetAllCars());
        }
        public ActionResult Users()
        {
            return View(adminService.GetAllUsers());
        }
        public ActionResult Bookings()
        {
            return View(adminService.GetAllBookings());
        }
    }
}
