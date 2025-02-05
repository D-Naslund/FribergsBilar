using FribergsBilar.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsBilar.Data
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        //Stops the cascade deletion of bookings if car is deleted from database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Car) 
                .WithMany()
                .HasForeignKey(b => b.CarId)
                .OnDelete(DeleteBehavior.SetNull); 
        }

    }
}
