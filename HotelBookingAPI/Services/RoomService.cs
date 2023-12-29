using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Repositories;

namespace HotelBookingAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly RoomRepository _repository;
       

        public RoomService(RoomRepository repository)
        {
            _repository = repository;
           
        }
        public Rooms AddRoom(Rooms room)
        {
            var myRoom = _repository.Add(room);
            return myRoom;
        }

        public Rooms DeleteRoom(int roomId, int hotelId)
        {
            var myRoom =_repository.Delete(roomId,hotelId);  
            
            return myRoom;
        }

        public IList<Rooms> GetAllRoomsOfHotel(int id)
        {
            var rooms = _repository.GetAll().Where(x => x.HotelId == id).ToList(); 
            return rooms.ToList();
        }

        public Rooms GetRoomById(int roomId, int hotelId)
        {
            var myRoom = _repository.Get(roomId,hotelId);
            return myRoom;
        }

        public IList<Rooms> GetRoomsByAvailability(int id, bool status)
        {
            var myHotel = GetAllRoomsOfHotel(id).ToList();
            List<Rooms> rooms = new List<Rooms>();
            foreach (var room in myHotel)
            {
                if(room.IsBooked==false) rooms.Add(room);
            }
            return rooms;
        }

        public IList<Rooms> GetRoomsBySize(int id, string size)
        {
            var myHotel = GetAllRoomsOfHotel(id).ToList();
            List<Rooms> rooms = new List<Rooms>();
            foreach (var room in myHotel)
            {
                if (room.RoomSize == size) rooms.Add(room);
            }
            return rooms.ToList();
        }

        public IList<Rooms> UpdateRoomPrice(RoomDTO room)
        {
           var myRooms= GetRoomsBySize(room.HotelId,room.RoomSize);
           foreach(var rooms in myRooms)
            {
                rooms.Price = room.Price;
            }
           return myRooms.ToList();
        }
    }
}
