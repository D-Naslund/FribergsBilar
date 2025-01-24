using FribergsBilar.Models;

namespace FribergsBilar.Data.Repositories
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CarRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public IEnumerable<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public Car GetbyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
