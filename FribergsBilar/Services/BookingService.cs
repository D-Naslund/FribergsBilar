using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;

namespace FribergsBilar.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUser userRepository;
        private readonly IBooking bookingRepository;
        private readonly ICar carRepository;

        public BookingService(IUser userRepository,IBooking bookingRepository, ICar carRepository )
        {
            this.userRepository = userRepository;
            this.bookingRepository = bookingRepository;
            this.carRepository = carRepository;
        }

        public void StartBooking(Car Car)
        {
            throw new NotImplementedException();
        }
    }
}
