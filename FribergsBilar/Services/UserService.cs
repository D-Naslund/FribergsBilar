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

        public void CreateUser(RegisterUser registerUser)
        {
            if(registerUser != null)
            {
                User user = new User();
                user.Email = registerUser.Email;
                user.Password = registerUser.Password;
                userRepository.Add(user);
            }
        }

        public async Task<User> LoginAsync(User user)
        {
            var tempUser = await userRepository.GetUserAsync(user);
            if(user != null && tempUser.Password == user.Password)
            {
                return tempUser;
            }
            return null;
        }

        public IEnumerable<Booking> GetSpecificUserBookings(int id)
        {
            return bookingRepository.GetUserBookings(id);
        }
    }
}
