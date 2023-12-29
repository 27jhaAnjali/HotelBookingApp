using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Hotel> _repository;

        public HotelService(IRepository<int,Hotel> repository)
        {
            _repository=repository;
        }
        public Hotel AddHotel(Hotel hotel)
        {
           var myHotel=_repository.Add(hotel);
            return myHotel;
        }

        public Hotel DeleteHotel(int id)
        {
         var hotel=_repository.Delete(id);
            return hotel;
            
        }

        public IList<Hotel> GetAllHotels()
        {
           return _repository.GetAll().ToList();
        }

        public IList<Hotel> GetHotelsByLocation(string location)
        {
           var myHotels=_repository.GetAll().Where(x=>x.Location==location).ToList();
            return myHotels;
        }

        public Hotel GetHotelsById(int id)
        {
            var myHotel = _repository.Get(id);
            return myHotel;
        }

        public Hotel UpdateHotelRating(HotelDTO hotel)
        {
            var myHotel=_repository.Get(hotel.Id);
            myHotel.Ratings = hotel.Ratings;
            _repository.Update(myHotel);
            return myHotel;
        }
    }
}
