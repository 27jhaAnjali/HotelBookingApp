using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Interfaces
{
    public interface IUserService
    {
        public UserDTO? UserSignIn(LoginDTO user);
        public UserDTO UserSignUp(UserDTO user);

        public User? GetMyUser();
    }
}
