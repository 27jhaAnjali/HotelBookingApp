using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace HotelBookingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _repository;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<string,User> repository,ITokenService tokenService)
        {
            _repository=repository;
            _tokenService = tokenService;
        }
        public UserDTO? UserSignIn(UserDTO user)
        {
            var isMyUser = _repository.Get(user.UserEmail);  //we get the user data with the entered name if it exists in the database
            var DbPassword = isMyUser.Password;
            HMACSHA512 hMACSHA512 = new HMACSHA512(isMyUser.Key); // we create an object of encryption algo using the encryption key of user in the database
            var encryptedUserPassword = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            if (DbPassword.Length == encryptedUserPassword.Length)
            {
                for (int i = 0; i < DbPassword.Length; i++)
                {
                    if (encryptedUserPassword[i] != DbPassword[i])
                        return null;
                }
                var loggedInUser = new UserDTO
                {
                    UserName = isMyUser.UserName,
                    Role = isMyUser.Role,
                    Token = _tokenService.GenerateToken(isMyUser.UserName, isMyUser.Role)
                };
                return loggedInUser;
            }
            return null;
        }
    

        public UserDTO UserSignUp(UserDTO user)
        {
          HMACSHA512 hMACSHA512 = new HMACSHA512();
          User myUser=new User();
            myUser.UserName = user.UserName;
            myUser.Password=hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            myUser.Key = hMACSHA512.Key;
            myUser.UserEmail = user.UserEmail;
            myUser.PhoneNumber= user.PhoneNumber;
            myUser.Role= user.Role;
            _repository.Add(myUser);
            var registeredUSer = new UserDTO
            {
                UserName = user.UserName,
                Role = user.Role,
                Token = _tokenService.GenerateToken(user.UserName, user.Role)
            };
            return registeredUSer;
        }
    }
}

