namespace HotelBookingAPI.Models.DTOs
{
    public class BookingDTO
    {
        public DateTime BookingDate { get; set; }
        public int HotelId { get; set; }
        public string? RoomSize { get; set; }

    }
}
