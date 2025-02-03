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
            return applicationDBContext.Cars.OrderBy(c => c.CarId);
        }

        public Car GetById(int id)
        {
            return applicationDBContext.Cars.FirstOrDefault( c => c.CarId == id);
        }
    }
}
