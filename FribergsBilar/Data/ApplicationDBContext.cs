using FribergsBilar.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsBilar.Data
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    }
}
