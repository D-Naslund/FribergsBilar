using FribergsBilar.Models;
using Microsoft.AspNetCore.Http;
using FribergsBilar.Services.Interfaces;
using Azure;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using FribergsBilar.Data.DataInterfaces;

namespace FribergsBilar.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IBookingRepository bookingRepository;

        public UserService(IUserRepository userRepository, IBookingRepository bookingRepository)
        {
            this.userRepository = userRepository;
            this.bookingRepository = bookingRepository;
        }

        public bool CreateUser(RegisterUser registerUser)
        {
            var doesUserExist = userRepository.GetUserByEmail(registerUser.Email);
            if(registerUser != null && doesUserExist == null)
            {
                User user = new User();
                user.Email = registerUser.Email;
                user.Password = registerUser.Password;
                userRepository.Add(user);
                return false;
            }
            return true;
        }

        public async Task<User> LoginAsync(User user)
        {

            var currentUser = await userRepository.GetUserAsync(user);
            if(currentUser != null && currentUser.Password == user.Password)
            {
                return currentUser;
            }
            //ta up vad man borde göra här
            return null;
        }

        public IEnumerable<Booking> GetSpecificUserBookings(int id)
        {
            return bookingRepository.GetUserBookings(id);
        }

        public User GetUser(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public void RemoveBooking(Booking booking)
        {
            bookingRepository.Delete(booking);
        }

        public Booking GetBookingById(int id)
        {
            return bookingRepository.GetById(id);
        }
    }
}
