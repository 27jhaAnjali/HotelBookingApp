using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelController(IHotelService service)
        {
            _service=service;
        }
        [HttpPost("AddHotel")]
        public ActionResult AddHotel(Hotel hotel)
        {
            try
            {
                var myHotel = _service.AddHotel(hotel);
                return Created("", myHotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllHotels")]
        public ActionResult GetAllHotels()
        {
            try
            {
                var hotels = _service.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public ActionResult RemoveHotel(int id)
        {
            try
            {
                var myHotel = _service.DeleteHotel(id);
                return Ok(myHotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetHotelsByLocaion")]
        public ActionResult HotelsByLocation(string location)
        {
            try
            {
                var myHotel = _service.GetHotelsByLocation(location);
                return Ok(myHotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult UpdateRatings(HotelDTO hotel)
        {
            try
            {
                var myHotel = _service.UpdateHotelRating(hotel);
                return Ok(myHotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
