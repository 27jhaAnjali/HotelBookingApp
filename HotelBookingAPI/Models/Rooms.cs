using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    public class Rooms
    {
            
            public int RoomNumber { get; set; }
            [Required]
            public string? RoomSize { get; set; }
            [Required]   
            public int HotelId { get; set; }
            [Required]
            public double Price { get; set; }
            [Required]
            public bool IsBooked { get; set; }

            [ForeignKey("HotelId")]
            public Hotel? Hotel { get; set; }
        }
    }

