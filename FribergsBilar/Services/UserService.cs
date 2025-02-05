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
        private readonly IUser userRepository;
        private readonly IBooking bookingRepository;

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
            if(currentUser != null && currentUser.Password == user.Password)
            {
                return currentUser;
            }
            //ta up vad man borde göra här
            return null;
        }

        public User GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public void AddUser(User user)
        {
            userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            userRepository.Delete(user);
        }
    }
}
