using HotelBookingAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBookingAPI.Services
{
    public class TokenService : ITokenService
    {
        byte[] key;
        public TokenService(IConfiguration configuration)
        {
            key=Encoding.UTF8.GetBytes(configuration.GetValue(typeof(string), "TokenKey").ToString());
        }
        public string GenerateToken(string UserEmail, string role)
        {
            string token = string.Empty;
            var subject = new ClaimsIdentity(new[]
           {
                new Claim(ClaimTypes.Email, UserEmail),
                new Claim(ClaimTypes.Role, role)
            });
            var tokenDescription = new SecurityTokenDescriptor(); 
            tokenDescription.Subject = subject;
            tokenDescription.Expires = DateTime.UtcNow.AddMinutes(20);
            var signature = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            tokenDescription.SigningCredentials = signature;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenObject = tokenHandler.CreateToken(tokenDescription);
            token = tokenHandler.WriteToken(tokenObject);
            return token;
        }
    }
}
