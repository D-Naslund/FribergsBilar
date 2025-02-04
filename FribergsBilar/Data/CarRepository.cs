using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CarRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Delete(Car car)
        {
            applicationDBContext.Remove(car);
            applicationDBContext.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDBContext.Cars.OrderBy(c => c.CarId);
        }

        public Car GetById(int id)
        {
            return applicationDBContext.Cars.FirstOrDefault(c => c.CarId == id);
        }
    }
}
