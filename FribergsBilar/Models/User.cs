using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; } = "";
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
