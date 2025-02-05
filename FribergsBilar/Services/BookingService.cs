using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;
using FribergsBilar.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FribergsBilar.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUserService userService;
        private readonly IBooking bookingRepository;
        private readonly ICarService carService;

        public BookingService(IUserService userService,IBooking bookingRepository, ICarService carService )
        {
            this.userService = userService;
            this.bookingRepository = bookingRepository;
            this.carService = carService;
        }

        public IEnumerable<Booking> GetSpecificUserBookings(int id)
        {
            return bookingRepository.GetUserBookings(id);
        }

        public Booking CreateBooking(DateTime startDate, DateTime endDate, int carId, int userId)
        {
           var currentCar = carService.GetCarById(carId);
           var currentUser = userService.GetUserById(userId);
           Booking newBooking = new Booking(currentCar.Name, startDate,endDate,currentCar,currentUser);
           bookingRepository.Add(newBooking);
            return newBooking;
        }
        public Booking GetBookingById(int id)
        {
            return bookingRepository.GetById(id);
        }

        public void DeleteBooking(Booking booking)
        {
            bookingRepository.Delete(booking);
        }


    }
}
