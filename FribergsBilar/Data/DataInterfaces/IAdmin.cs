using FribergsBilar.Models;

namespace FribergsBilar.Data.DataInterfaces
{
    public interface IAdmin
    {
        Task<Admin> GetAdminAsync(Admin admin);
    }
}
