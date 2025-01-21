using FribergsBilar.Models;

namespace FribergsBilar.Services.Interfaces
{
    public interface IUser
    {
        Task<User> GetUserAsync(string email, string password);
    }
}
