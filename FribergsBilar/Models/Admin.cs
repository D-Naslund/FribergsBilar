using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Användare saknas")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Lösenordet saknas")]
        public string Password { get; set; } = string.Empty;

    }
}
