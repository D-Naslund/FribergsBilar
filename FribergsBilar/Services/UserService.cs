using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Data.Repositories;
using Microsoft.AspNetCore.Http;
using FribergsBilar.Services.Interfaces;
using Azure;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace FribergsBilar.Services
{
    public class UserService : IUserService
    {
        private readonly IUser userRepository;
        private readonly IBooking bookingRepository;

        private User CurrentUser { get; set; }

        public UserService(IUser userRepository, IBooking bookingRepository)
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
            if(user != null && currentUser.Password == user.Password)
            {
                return currentUser;
            }
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
    }
}
