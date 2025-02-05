using FribergsBilar.Data;
using FribergsBilar.Models;

namespace FribergsBilar.Services.Interfaces
{
    public interface IBookingService
    {
        Booking CreateBooking(DateTime start, DateTime end, int carId, int userId);
        Booking GetBookingById(int id);
        void DeleteBooking(Booking booking);
        IEnumerable<Booking> GetSpecificUserBookings(int id);

    }
}
