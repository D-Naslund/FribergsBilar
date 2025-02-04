using FribergsBilar.Models;

namespace FribergsBilar.Data.DataInterfaces
{
    public interface IAdminRepository
    {
        Task<Admin> GetAdminAsync(Admin admin);
    }
}
