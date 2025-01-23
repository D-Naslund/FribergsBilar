using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService authService;
        public UserController(IUserService authService)
        {
            this.authService = authService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
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
        public async Task<ActionResult> Login(User user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = await authService.LoginAsync(user.Email, user.Password);
                    if(result == true)
                    {
                        Response.Cookies.Append("loggedIn", user.Email);
                        return RedirectToAction("Privacy", "Home");
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
        public ActionResult Register(User user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    authService.CreateUser(user);
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
