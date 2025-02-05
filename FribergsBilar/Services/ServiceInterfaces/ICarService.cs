using FribergsBilar.Models;

namespace FribergsBilar.Services.ServiceInterfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetCarList();

        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);

        Car GetCarById(int CarId);
    }
}
