using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Interfaces
{
    public interface IUserService
    {
        public UserDTO? UserSignIn(UserDTO user);
        public UserDTO UserSignUp(UserDTO user);

    }
}
