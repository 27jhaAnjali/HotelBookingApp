using HotelBookingAPI.Contexts;
using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly HotelContext _context;

        public UserRepository(HotelContext context)
        {
            _context=context;
        }
        public User Add(User entity)
        {
            _context.users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Delete(string key)
        {
            var myUser = Get(key);
            if (myUser != null)
            {
                _context.users.Remove(myUser);
                _context.SaveChanges();
                return myUser;
            }
            throw new UserNotFoundException();
        }

        public User Get(string key)
        {
            var myUser = _context.users.FirstOrDefault(x => x.UserEmail == key);
            return myUser;
        }


        public IList<User> GetAll()
        {
            var users= _context.users.ToList(); 
            if(users.Count!=0)
            {
                return users;
            }
            throw new NoUserInTheDataBaseException();
        }

        public User Update(User entity)
        {
           _context.Entry<User>(entity).State=EntityState.Modified;
           _context.SaveChanges();
           return entity;
        }
    }
}
