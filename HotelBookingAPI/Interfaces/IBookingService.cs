using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Interfaces
{
    public interface IBookingService
    {
        public Bookings NewBooking(BookingDTO booking);
        public bool CheckAvailability(BookingDTO booking);
        public IList<Bookings> GetAll();
    }
}
