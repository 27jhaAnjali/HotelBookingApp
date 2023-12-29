using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Name is mandatory")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})", ErrorMessage = "Invalid email address")]
        public string? UserEmail { get; set; }
        [Required(ErrorMessage = "Phone is mandatory")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        public byte[]? Password { get; set; }
        public byte[]? Key { get; set; }
        [Required(ErrorMessage = "Role is mandatory")]
        public string? Role { get; set; }
    }
}
