using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public int RoomNo { get; set; }

    }
    }

