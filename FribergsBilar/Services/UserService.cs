using FribergsBilar.Data;
using FribergsBilar.Models;
using FribergsBilar.Repositories;
using Microsoft.AspNetCore.Http;
using FribergsBilar.Services.Interfaces;

namespace FribergsBilar.Services
{
    public class UserService : IUserService
    {
        private readonly IUser userRepository;

        public UserService(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            if(user != null)
            {
                userRepository.Add(user);
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await userRepository.GetUserAsync(email,password);
            if (user == null)
            {
                return false;
            }

            var passwordValid = user.Password == password;
            if(!passwordValid)
            {
                return false;
            }
           
            return true;
        }
    }
}
