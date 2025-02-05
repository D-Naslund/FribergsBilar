using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsBilar.Data
{
    public class BookingRepository : IBooking
    {

        private readonly ApplicationDBContext applicationDBContext;

        public BookingRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public async void Add(Booking booking)
        {
            await applicationDBContext.Bookings.AddAsync(booking);
            applicationDBContext.SaveChanges();
        }

        public void Update(Booking booking)
        {
            applicationDBContext.Bookings.Update(booking);
            applicationDBContext.SaveChanges();
        }

        public void Delete(Booking booking)
        {
            applicationDBContext.Bookings.Remove(booking);
            applicationDBContext.SaveChanges();

        }

        public IEnumerable<Booking> GetAll()
        {
            return applicationDBContext.Bookings.Include(b => b.User).OrderBy(b => b.BookingId);
        }

        public Booking GetById(int id)
        {
            return applicationDBContext.Bookings.SingleOrDefault(b => b.BookingId == id);
        }

        public IEnumerable<Booking> GetUserBookings(int id)
        {
            return applicationDBContext.Bookings.Where(u => u.User.UserId == id);
        }
    }
}
