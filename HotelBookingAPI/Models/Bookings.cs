using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public string? RoomSize { get; set; }

        public double Price { get; set; }

        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; } //single object as 1 appoinment is only mapped to 1 patient

        [ForeignKey("UserId")]
        public User? User { get; set; }

    }
}

