using HotelBookingAPI.Contexts;
using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Utilities.Exceptions;

namespace HotelBookingAPI.Repositories
{
    public class HotelRepository : IRepository<int, Hotel>
    {
        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context=context;
        }
        public Hotel Add(Hotel entity)
        {
            _context.hotels.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Hotel Delete(int key)
        {
            var myHotel = Get(key);
            if(myHotel != null)
            {
                _context.hotels.Remove(myHotel);
                _context.SaveChanges();
                return myHotel;
            }
            throw new HotelNotFoundException();
        }

        public Hotel Get(int key)
        {
            var myHotel= _context.hotels.FirstOrDefault(x=>x.HotelId==key);
            if(myHotel==null)
            {
                throw new HotelNotFoundException();
            }
            return myHotel;
        }

        public IList<Hotel> GetAll()
        {
            var hotels=_context.hotels;
            if(hotels == null)
            {
                throw new NoHotelsAvailableException();
            }
            return hotels.ToList();
        }

        public Hotel Update(Hotel entity)
        {
         _context.Entry<Hotel>(entity).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
