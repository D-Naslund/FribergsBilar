using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string CarName { get; set; } = "";
        public DateTime StartDate { get; set; }
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
