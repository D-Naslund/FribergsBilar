using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public interface IUser
    {
        Task<User> GetUserAsync(string email, string password);

        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
