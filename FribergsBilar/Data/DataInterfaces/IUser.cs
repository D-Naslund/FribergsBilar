using FribergsBilar.Models;

namespace FribergsBilar.Data.DataInterfaces
{
    public interface IUser
    {
        Task<User> GetUserAsync(User user);
        User GetUserById(int id);

        User GetUserByEmail(string email);
        IEnumerable<User> GetAll();

        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
