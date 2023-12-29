using HotelBookingAPI.Contexts;
using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Utilities.Exceptions;

namespace HotelBookingAPI.Repositories
{
    public class RoomRepository 
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context=context;
        }
        public Rooms Add(Rooms entity)
        {
            _context.rooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Rooms Delete(int roomID, int hotelID)
        {
            var myRoom = Get(roomID, hotelID);  
            if (myRoom != null)
            {
                _context.rooms.Remove(myRoom);
                _context.SaveChanges();
                return myRoom;
            }
            throw new RoomNotFoundException();
        }

        public Rooms Get(int roomID,int hotelID)
        {
            var myRoom = _context.rooms.FirstOrDefault(x => x.RoomNumber == roomID&& x.HotelId==hotelID);
            if (myRoom == null)
            {
                throw new RoomNotFoundException();
            }
            return myRoom;
        }

        public IList<Rooms> GetAll()
        {
            var rooms = _context.rooms;
            if (rooms == null)
            {
                throw new NoRoomsAvailableException();
            }
            return rooms.ToList();
        }

        public Rooms Update(Rooms entity)
        {
            _context.Entry<Rooms>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
