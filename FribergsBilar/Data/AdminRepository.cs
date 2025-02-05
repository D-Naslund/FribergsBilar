using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsBilar.Data
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDBContext applicationDBContext;

        public AdminRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public async Task<Admin> GetAdminAsync(Admin admin)
        {
            return await applicationDBContext.Admins.FirstOrDefaultAsync(a=> a.Username == admin.Username);
        }
    }
}
