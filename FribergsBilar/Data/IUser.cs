using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public interface IUser
    {
        Task<User> GetUserAsync(User user);

        IEnumerable<User> GetAll();

        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
