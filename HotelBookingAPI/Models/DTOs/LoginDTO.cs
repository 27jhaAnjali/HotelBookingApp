using System.Text.Json.Serialization;

namespace HotelBookingAPI.Models.DTOs
{
    public class LoginDTO
    {
            [JsonIgnore]
            public string? UserName { get; set; }
            public string? UserEmail { get; set; }
            [JsonIgnore]
            public string? PhoneNumber { get; set; }

            public string? Password { get; set; }

            public string? Role { get; set; }
            [JsonIgnore]
            public string? Token { get; set; }
     
    }
}
