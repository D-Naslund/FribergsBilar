using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Car Car { get; set; }
        public User User { get; set; }
    }
}
