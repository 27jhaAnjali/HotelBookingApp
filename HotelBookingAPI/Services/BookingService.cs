using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Repositories;
using HotelBookingAPI.Utilities.Exceptions;

namespace HotelBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, Bookings> _repository;
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;

        public BookingService(IRepository<int, Bookings> repository,IRoomService roomService,IUserService userService)
        {
            _repository = repository;
            _roomService=roomService;
            _userService = userService;
        }
        public bool CheckAvailability(BookingDTO booking)
        {
           
                var roomsBySize = _roomService.GetRoomsBySize(booking.HotelId, booking.RoomSize).ToList();
                var checkBooking = roomsBySize.FirstOrDefault(b=>b.IsBooked== false);
                if (checkBooking != null)
                    return true;
                else
                    return false;
            }

        public IList<Bookings> GetAll()
        {
            try
            {
                var myBookings = _repository.GetAll();
                return myBookings;
            }
            catch(Exception ex)
            {
                throw new NoBookingsAvailableException();
            }
        }

        public Bookings NewBooking(BookingDTO booking)
        {
            try
            {
                if (CheckAvailability(booking) == true)
                {
                    var roomsBySize = _roomService.GetRoomsBySize(booking.HotelId, booking.RoomSize).FirstOrDefault();
                   /* var id = userID;*/
                    Bookings myBooking = new Bookings()
                    {
                        BookingDate = booking.BookingDate,
                        HotelId = booking.HotelId,
                        RoomSize = booking.RoomSize,
                        Price= roomsBySize.Price,
                        UserId = _userService.GetMyUser().UserId
                    };
                    var booked = _repository.Add(myBooking);
                    _roomService.UpdateRoomStatus(myBooking.HotelId,roomsBySize.RoomNumber,roomsBySize.IsBooked=true);
                    return booked;
                }
                else
                {
                    throw new BookingCouldNotBeAddedException();
                }
            }
            catch( Exception ex )
            {

                throw new RoomNotAvailabeException();
            }
          
            
        }
    }
}
