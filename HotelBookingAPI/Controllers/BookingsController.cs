using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet("GetAllBookings")]
        public ActionResult GetBookings()
        {
            try
            {
                var bookings = _service.GetAll().ToList();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPost("AddNewBookings")]
        public ActionResult BookHotelRoom(BookingDTO booking)
        {
            try
            {
                var myBooking = _service.NewBooking(booking);
                return Created("",myBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    
    }
}
