using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public interface IBooking
    {
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
    }
}
