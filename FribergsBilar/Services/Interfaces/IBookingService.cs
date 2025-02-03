using FribergsBilar.Models;

namespace FribergsBilar.Services.Interfaces
{
    public interface IBookingService
    {
        public Booking CreateBooking(DateTime start, DateTime end, int carId, int userId);
        public Booking ConfirmationBooking(int id);

        public IEnumerable<Booking> GetBookingList();
        public IEnumerable<Car> GetCarList();

        void DeleteCar(Car car);

        public Car GetCarById(int CarId);
    }
}
