namespace FribergsBilar.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Car car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
