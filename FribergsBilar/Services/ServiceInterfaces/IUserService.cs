using FribergsBilar.Models;
using Humanizer.Localisation.DateToOrdinalWords;

namespace FribergsBilar.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginAsync(User user);
        User GetUserById(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        bool DeleteUser(User user);
        bool CreateUser(RegisterUser registerUser);

    }
}
