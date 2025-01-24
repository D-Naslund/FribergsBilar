using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public interface ICar
    {
        Car GetbyId(int id);
        IEnumerable<Car> GetAll();
    }
}
