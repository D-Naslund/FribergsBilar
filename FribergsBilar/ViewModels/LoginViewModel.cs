using FribergsBilar.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FribergsBilar.ViewModels
{
    public class LoginViewModel
    {
        public User User { get; set; }
        public RegisterUser RegisterUser { get; set; }
    }
}
