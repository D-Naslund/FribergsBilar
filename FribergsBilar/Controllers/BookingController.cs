using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;
using FribergsBilar.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace FribergsBilar.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;
        private readonly ICarService carService;

        public BookingController(IBookingService bookingService, ICarService carService)
        {
            this.bookingService = bookingService;
            this.carService = carService;
        }
        // GET: BookingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bookingService.GetBookingById(id));
        }

        // POST: BookingController/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Booking booking)
        {
            try
            {
                if(HttpContext.Session.GetString("isAdmin") != null)
                {
                    bookingService.DeleteBooking(booking);
                    return RedirectToAction("Bookings", "Admin");
                }
                else
                {
                    bookingService.DeleteBooking(booking);
                    return RedirectToAction("Profile", "User");
                }


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
                var currentCar = carService.GetCarById(carId);
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
                if (booking.StartDate > DateTime.Now && booking.EndDate > booking.StartDate)
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
                else
                {
                    TempData["FailureDateMessage"] = "Ogiltiga datum!\n Vänlig försök igen";
                    return RedirectToAction("Date");
                }
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
