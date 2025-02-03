using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();

        void Delete(Car car);
    }
}
