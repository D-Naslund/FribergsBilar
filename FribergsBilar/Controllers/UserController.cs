using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;
using FribergsBilar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: UserController
        public ActionResult Profile()
        {
            if(HttpContext.Session.GetInt32("CurrentId") != null)
            {
                int currentUser = (int)HttpContext.Session.GetInt32("CurrentId");
                var user = userService.GetSpecificUserBookings(currentUser);
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Login
        public ActionResult Login()
        {

            return View();
        }

        // POST: UserController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginVM )
        {
            try
            {
                ModelState.Remove("RegisterUser");
                if (ModelState.IsValid)
                {
                    var user = await userService.LoginAsync(loginVM.User);
                    if(user != null)
                    {
                        HttpContext.Session.SetString("CurrentEmail", user.Email);
                        HttpContext.Session.SetInt32("CurrentId", user.UserId);

                        return RedirectToAction("Profile", "User");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            try
            {
                Response.Cookies.Delete("loggedIn");
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LoginViewModel LoginVM)
        {
            try
            {
                ModelState.Remove("User");
                if (ModelState.IsValid)
                {
                    userService.CreateUser(LoginVM.RegisterUser);
                    return RedirectToAction("Login", "User");
                    
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
