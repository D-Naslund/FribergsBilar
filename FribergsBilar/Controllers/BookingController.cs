using FribergsBilar.Data.Repositories;
using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace FribergsBilar.Controllers
{
    public class BookingController : Controller
    {
        public IBookingService bookingService { get; }

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        // GET: BookingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View(bookingService.GetCarById(id));
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Cars()
        {
            ViewData["loggedIn"] = HttpContext.Session.GetString("CurrentEmail");
            var carsList = bookingService.GetCarList();
            return View(carsList);
        }

        [HttpPost]
        public ActionResult BookCar(int id)
        {
            try
            {
                if(ModelState.IsValid)
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

        public ActionResult Date()
        {
            ViewData["loggedIn"] = HttpContext.Session.GetString("CurrentEmail");
            var carId = (int)HttpContext.Session.GetInt32("BookingInProcess");
            if(carId != 0)
            {
                var currentCar = bookingService.GetCarById(carId);
                ViewData["CurrentCarData"] = currentCar.Name;
                return View();
            }
            else
            {
                return RedirectToAction("Cars", "Booking");
            }
        }
        [HttpPost]
        public ActionResult Date(Booking booking)
        {
            try
            {
                if (booking.StartDate != DateTime.MinValue && booking.EndDate != DateTime.MinValue)
                {
                    var carId = (int)HttpContext.Session.GetInt32("BookingInProcess");
                    var userId = (int)HttpContext.Session.GetInt32("CurrentId");
                    if (carId != 0 && userId != 0)
                    {
                        var currentBooking = bookingService.CreateBooking(booking.StartDate, booking.EndDate, carId, userId);

                        //Adds time for some reason?
                        TempData["ConfirmationCarName"] = currentBooking.CarName;
                        TempData["ConfirmationStartDate"] = currentBooking.StartDate.ToString("yyyy/MM/dd");
                        TempData["ConfirmationEndDate"] = currentBooking.EndDate.ToString("yyyy/MM/dd");

                        return RedirectToAction("Confirmation", "Booking");
                    }
                    return RedirectToAction("Error", "Home");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirmation()
        {
            ViewData["loggedIn"] = HttpContext.Session.GetString("CurrentEmail");
            return View();
        }
    }
}
