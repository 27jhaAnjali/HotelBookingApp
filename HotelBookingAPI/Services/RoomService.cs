using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Repositories;
using HotelBookingAPI.Utilities.Exceptions;

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

        public IList<Rooms> GetRoomsByAvailability(int hotelId)
        {
            var myHotel = GetAllRoomsOfHotel(hotelId).ToList();
            List<Rooms> rooms = new List<Rooms>();
            foreach (var room in myHotel)
            {
                if(room.IsBooked==false) rooms.Add(room);
            }
            return rooms;
        }

        public IList<Rooms>? GetRoomsBySize(int id, string size)
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
                _repository.Update(rooms);
            }
           return myRooms.ToList();
        }
        public Rooms UpdateRoomStatus(int hotelID,int roomNumber,bool isBooked)
        {
            var myRoom = _repository.Get(roomNumber, hotelID);
            if (myRoom != null)
            {
                _repository.Update(myRoom);
                return myRoom;
            }
            else
                throw new RoomNotFoundException();
        }
    }
}
