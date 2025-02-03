using FribergsBilar.Models;

namespace FribergsBilar.Data.Repositories
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

        public void Delete(Booking booking)
        { 
            applicationDBContext.Remove(booking);
            applicationDBContext.SaveChanges();

        }

        public IEnumerable<Booking> GetAll()
        {
            return applicationDBContext.Bookings.OrderBy(b => b.BookingId);
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
