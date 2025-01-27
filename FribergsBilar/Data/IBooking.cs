using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public interface IBooking
    {
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();

        void Add(Booking booking);
        void Delete(Booking booking);
    }
}
