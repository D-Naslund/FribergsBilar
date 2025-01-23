using FribergsBilar.Models;

namespace FribergsBilar.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> LoginAsync(string email, string password);

        void CreateUser(User user);
    }
}
