using FribergsBilar.Repositories;
using FribergsBilar.Services.Interfaces;

namespace FribergsBilar.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUser userRepository;

        public AuthService(IUser userRepository)
        {
            this.userRepository = userRepository;
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
