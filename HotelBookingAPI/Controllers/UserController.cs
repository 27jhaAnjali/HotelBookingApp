using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service=service;
        }

        [HttpPost("Login")]

        public ActionResult Login(LoginDTO user)
        {
            var myUser= _service.UserSignIn(user);
            if(myUser != null)
            { 
                return Ok(myUser);
            }
            return Unauthorized();
        }

        [HttpPost("SignUp")]

        public ActionResult SignUp(UserDTO user) 
        {
            var myUser=_service.UserSignUp(user);
            if(myUser != null)
            {
                return Created("", myUser);
            }
            return BadRequest();
        }

     
        [HttpPost("GetCurrent")]
        public ActionResult GetMeMyUser()
        {
            try
            {
                var user = _service.GetMyUser();
              
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
           
       
    }
    }

