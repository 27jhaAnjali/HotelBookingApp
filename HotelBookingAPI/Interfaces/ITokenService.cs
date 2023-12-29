using HotelBookingAPI.Models;

namespace HotelBookingAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string UserEmail, string role);
    }
}
