using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service=service;
        }

        [HttpGet("RoomBySize")]
        public IActionResult Get(int id, string size)
        {
            try
            {
             var rooms= _service.GetRoomsBySize(id, size);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("RoomById")]
        public IActionResult Get(int roomId, int hotelId)
        {
            try
            {
                var myRoom = _service.GetRoomById(roomId,hotelId);
                return Ok(myRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddNewRoom")]
        public IActionResult AddingRoom(Rooms room)
        {
            try
            {
                var myRoom =_service.AddRoom(room);
                return Created("",myRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RemoveRoom")]
        public IActionResult RemovingRooms(int hotelId,int roomId)
        {
            try
            {
                var myRoom = _service.DeleteRoom(hotelId, roomId);
                return Ok(myRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("AllRooms")]
        public IActionResult AllRooms(int hotelId)
        {
            try
            {
                var myRoom = _service.GetAllRoomsOfHotel(hotelId);
                return Ok(myRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PriceUpdate")]
        public IActionResult RoomPriceUpdate(RoomDTO room)
        {
            try
            {
                var myRoom = _service.UpdateRoomPrice(room);
                return Ok(myRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("AvailableRooms")]
        public IActionResult AvailableRooms(int hotelId)
        {
            try
            {
                var availableRooms = _service.GetRoomsByAvailability(hotelId);
                return Ok(availableRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
