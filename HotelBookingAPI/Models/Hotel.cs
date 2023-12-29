using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [Required]
        public string? HotelName { get; set; }
        [Required(ErrorMessage = "Location is mandatory")]
        public string? Location { get; set; }
        [Required]
        public int TotalRooms { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Ratings { get; set; }
        public ICollection<Rooms> roomss { get; set; }

        /*        [Required]
                public string[]? Reviews { get; set; }

                [Required]
                public string[]? Amenities { get; set; }*/
    }
}
