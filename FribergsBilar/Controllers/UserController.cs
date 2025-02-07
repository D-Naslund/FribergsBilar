using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Services;
using FribergsBilar.Services.Interfaces;
using FribergsBilar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IBookingService bookingService;

        public UserController(IUserService userService, IBookingService bookingService)
        {
            this.userService = userService;
            this.bookingService = bookingService;
        }

        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        [AdminAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userService.AddUser(user);
                }
                return RedirectToAction("Users", "Admin");
            }
            catch
            {
                return View();
            }
        }

        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            User user = new User();
            user = userService.GetUserById(id);
            return View(user);
        }


        [AdminAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userService.UpdateUser(user);
                }
                return RedirectToAction("Users", "Admin");
            }
            catch
            {
                return View();
            }
        }

        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            return View(userService.GetUserById(id));
        }

        // POST: BookingController/Delete/5
        [AdminAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            try
            {
                var userDeleted =  userService.DeleteUser(user);
                if(userDeleted == true)
                {
                    return RedirectToAction("Users", "Admin");
                }
                else
                {
                    TempData["UserDeleteFail"] = "Användaren har bokningar och kan inte bli bort tagen!";
                    return RedirectToAction("Delete");
                }
                
            }
            catch
            {
                return View();
            }
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
                        if(HttpContext.Session.GetInt32("BookingInProcess") != null)
                        {
                            return RedirectToAction("Date", "Booking");
                        }
                        return RedirectToAction("Profile", "User");
                    }
                    else
                    {
                        TempData["FailureLoginMessage"] = "Login Misslyckades \n Vänligen Försök igen!";
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
                if(ModelState.IsValid)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Index", "Home");
                }
                return View();
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
                    var userExist = userService.CreateUser(LoginVM.RegisterUser);
                    if(userExist == false)
                    {
                        TempData["SuccessRegisterMessage"] = "Registrering Lyckad \n Vänligen logga in!";
                    }
                    else
                    {
                        TempData["FailureRegisterMessage"] = "Registrering Misslyckades \n Vänligen Försök igen!";
                    }
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

        public ActionResult Profile()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["loggedIn"] = HttpContext.Session.GetString("CurrentEmail");
                    if (HttpContext.Session.GetInt32("CurrentId") != null)
                    {
                        int currentUser = (int)HttpContext.Session.GetInt32("CurrentId");
                        var userBookings = bookingService.GetBookingsToProfile(currentUser);
                        return View(userBookings);
                    }
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }
    }
}
