using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FribergsBilar.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUserService userService;
        private readonly IBooking bookingRepository;
        private readonly ICar carRepository;

        public BookingService(IUserService userService,IBooking bookingRepository, ICar carRepository )
        {
            this.userService = userService;
            this.bookingRepository = bookingRepository;
            this.carRepository = carRepository;
        }

        public IEnumerable<Booking> GetBookingList()
        {
            return null;
        }

        public void StartBooking(Car Car)
        {
           
        }
    }
}
