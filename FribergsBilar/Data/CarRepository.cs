using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;

namespace FribergsBilar.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CarRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Add(Car car)
        {
            applicationDBContext.Cars.Add(car);
            applicationDBContext.SaveChanges();
        }

        public void Update(Car car)
        {
            applicationDBContext.Cars.Update(car);
            applicationDBContext.SaveChanges();
        }        

        public void Delete(Car car)
        {
            applicationDBContext.Cars.Remove(car);
            applicationDBContext.SaveChanges();
        }
        public void DeactivateCar(Car car)
        {
            applicationDBContext.Cars.Update(car);
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
