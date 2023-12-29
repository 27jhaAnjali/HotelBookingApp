using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Interfaces
{
    public interface IHotelService
    {
        public Hotel AddHotel(Hotel hotel);
        public IList<Hotel> GetAllHotels();
        public IList<Hotel> GetHotelsByLocation(string location);
        public Hotel GetHotelsById(int id);
        public Hotel DeleteHotel(int id);
        public Hotel UpdateHotelRating(HotelDTO hotel);
     //   public Hotel getHotelByRoomAvailability(Hotel hotel);     

    }
}
