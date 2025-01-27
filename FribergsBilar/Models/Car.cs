using System.ComponentModel.DataAnnotations;

namespace FribergsBilar.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public int Seats { get; set; }
        public int Price { get; set; } 

    }
}
