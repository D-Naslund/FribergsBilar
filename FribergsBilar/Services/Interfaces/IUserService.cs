using FribergsBilar.Models;

namespace FribergsBilar.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginAsync(User user);

        void CreateUser(RegisterUser registerUser);

        IEnumerable<Booking> GetSpecificUserBookings(int id);

    }
}
