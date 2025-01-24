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
        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Booking GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
