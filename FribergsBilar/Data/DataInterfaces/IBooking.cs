using FribergsBilar.Models;

namespace FribergsBilar.Data.DataInterfaces
{
    public interface IBooking
    {
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
        IEnumerable<Booking> GetUserBookings(int id);
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(Booking booking);
    }
}
