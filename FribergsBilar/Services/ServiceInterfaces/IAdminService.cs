using FribergsBilar.Models;

namespace FribergsBilar.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Admin> LoginAdminAsync(Admin admin);

        IEnumerable<Car> GetAllCars();
        IEnumerable<User> GetAllUsers();
        IEnumerable<Booking> GetAllBookings();
    }
}
