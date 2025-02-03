using FribergsBilar.Models;
using Humanizer.Localisation.DateToOrdinalWords;

namespace FribergsBilar.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginAsync(User user);
        User GetUser(int userId);

        Booking GetBookingById(int id);
        void RemoveBooking(Booking booking);

        bool CreateUser(RegisterUser registerUser);

        IEnumerable<Booking> GetSpecificUserBookings(int id);

    }
}
