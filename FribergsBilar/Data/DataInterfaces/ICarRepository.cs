using FribergsBilar.Models;

namespace FribergsBilar.Data.DataInterfaces
{
    public interface ICarRepository
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();

        void Delete(Car car);
    }
}
