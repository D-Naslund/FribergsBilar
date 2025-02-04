using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FribergsBilar.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUserService userService;
        private readonly IBookingRepository bookingRepository;
        private readonly ICarRepository carRepository;

        public BookingService(IUserService userService,IBookingRepository bookingRepository, ICarRepository carRepository )
        {
            this.userService = userService;
            this.bookingRepository = bookingRepository;
            this.carRepository = carRepository;
        }

        public IEnumerable<Booking> GetBookingList()
        {
            return null;
        }

        public Booking CreateBooking(DateTime startDate, DateTime endDate, int carId, int userId)
        {
           var currentCar = GetCarById(carId);
           var currentUser = userService.GetUser(userId);
           Booking newBooking = new Booking(currentCar.Name, startDate,endDate,currentCar,currentUser);
           bookingRepository.Add(newBooking);
            return newBooking;
        }

        public IEnumerable<Car> GetCarList()
        {
            return carRepository.GetAll();
        }

        public Car GetCarById(int carId)
        {
            return carRepository.GetById(carId);
        }

        public Booking ConfirmationBooking(int id)
        {
            return bookingRepository.GetById(id);
        }

        public void DeleteCar(Car car)
        {
            carRepository.Delete(car);
        }
    }
}
