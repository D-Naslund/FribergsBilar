using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Mailadressen saknas")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Lösenordet saknas")]
        //[PasswordPropertyText]
        public string Password { get; set; } = "";
        public virtual ICollection<Booking>? Bookings { get; set; } = new List<Booking>();
    }
}
