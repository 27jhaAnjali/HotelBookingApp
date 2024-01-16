using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Interfaces
{
    public interface IRoomService
    {
        public Rooms AddRoom(Rooms room);
        public IList<Rooms> GetAllRoomsOfHotel(int id);
        public IList<Rooms> GetRoomsByAvailability(int id);
        public Rooms GetRoomById(int roomId, int hotelId);
        public IList<Rooms> GetRoomsBySize(int id,string size);
        public Rooms DeleteRoom(int roomId, int hotelId);
        public IList<Rooms> UpdateRoomPrice(RoomDTO room);
        public Rooms UpdateRoomStatus(int hotelID, int roomNumber, bool isBooked);   //7676702116
    }
}
