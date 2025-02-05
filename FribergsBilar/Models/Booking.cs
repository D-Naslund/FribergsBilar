using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int? CarId { get; set; }
        public int? UserId { get; set; }
        public string CarName { get; set; } = "";
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public virtual bool IsCompleted { get; set; }
        public Car Car { get; set; }
        public User User { get; set; }

        public Booking() { }

        public Booking(string carName, DateTime startDate, DateTime endDate, Car car, User user) 
        {
            CarName = carName;
            StartDate = startDate;
            EndDate = endDate;
            Car = car;
            User = user;
        }
    }
}
