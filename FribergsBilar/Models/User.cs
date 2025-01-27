using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "The password is required")]
        //[PasswordPropertyText]
        public string Password { get; set; } = "";
        public virtual ICollection<Booking>? Bookings { get; set; }
        public virtual ICollection<Booking>? PreviousBookings { get; set; }
    }
}
