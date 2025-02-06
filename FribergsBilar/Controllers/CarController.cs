using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Services;
using FribergsBilar.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergsBilar.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        // GET: CarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarController/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [AdminAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carService.AddCar(car);
                }
                return RedirectToAction("Cars", "Admin");
            }
            catch
            {
                return View();
            }
        }
        [AdminAuthorize]
        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            Car car = new Car();
            car = carService.GetCarById(id);
            return View(car);
        }

        // POST: CarController/Edit/5
        [AdminAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carService.UpdateCar(car);
                }
                return RedirectToAction("Cars","Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int id)
        {
            return View(carService.GetCarById(id));
        }

        // POST: CarController/Delete/5
        [AdminAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Car car)
        {
            try
            {
                carService.DeleteCar(car);
                return RedirectToAction("Cars", "Admin");
            }
            catch
            {
                return View();
            }
        }
    }
}
