using FribergsBilar.Data;
using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Models;
using FribergsBilar.Services.Interfaces;

namespace FribergsBilar.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdmin adminRepository;
        private readonly IBooking bookingRepository;
        private readonly ICar carRepository;
        private readonly IUser userRepository;

        public AdminService(IAdmin adminRepository, IBooking bookingRepository, ICar carRepository, IUser userRepository)
        {
            this.adminRepository = adminRepository;
            this.bookingRepository = bookingRepository;
            this.carRepository = carRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return bookingRepository.GetAll();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return carRepository.GetAll();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public async Task<Admin> LoginAdminAsync(Admin admin)
        {

            var currentAdmin = await adminRepository.GetAdminAsync(admin);
            if (currentAdmin != null && currentAdmin.Password == admin.Password)
            {
                return currentAdmin;
            }
            //ta up vad man borde göra här
            return null;
        }
    }
}
