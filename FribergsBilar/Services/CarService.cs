using FribergsBilar.Data;
using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;
using FribergsBilar.Services.ServiceInterfaces;
using Microsoft.Identity.Client;

namespace FribergsBilar.Services
{
    public class CarService : ICarService
    {
        private readonly ICar carRepository;

        public CarService(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IEnumerable<Car> GetCarList()
        {
            return carRepository.GetAll();
        }

        public Car GetCarById(int carId)
        {
            return carRepository.GetById(carId);
        }
        public void AddCar(Car car)
        {
            carRepository.Add(car);
        }

        public void UpdateCar(Car car)
        {
            carRepository.Update(car);
        }

        public void DeleteCar(Car car)
        {
            carRepository.Delete(car);
        }
    }
}
