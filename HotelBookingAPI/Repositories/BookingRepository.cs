using HotelBookingAPI.Contexts;
using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Repositories
{
    public class BookingRepository : IRepository<int, Bookings>
    {
        private readonly HotelContext _context;

        public BookingRepository(HotelContext context)
        {
            _context = context;
        }
        public Bookings Add(Bookings entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Bookings Delete(int key)
        {
            var myBooking = Get(key);
            if (myBooking == null)
                throw new BookingNotFoundException();
            _context.bookinggs.Remove(myBooking);
            _context.SaveChanges();
            return myBooking;
        }

        public Bookings Get(int key)
        {
            var myBooking = _context.bookinggs.SingleOrDefault(app => app.BookingId == key);
            if (myBooking != null)
                return myBooking;
            throw new BookingNotFoundException(); 
        }

        public IList<Bookings> GetAll()
        {
            var myBookings = _context.bookinggs;
            if (myBookings.Count() == 0)
                throw new NoBookingsAvailableException();
            return myBookings.ToList();
        }

        public Bookings Update(Bookings entity)
        {
            var myBookings = Get(entity.BookingId);
            if (myBookings != null)
            {
                _context.Entry<Bookings>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
             throw new BookingNotFoundException();
        }
    }
}
