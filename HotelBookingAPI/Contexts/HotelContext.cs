using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Contexts
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<User>? users { get; set; }
        public DbSet<Hotel>? hotels { get; set; }
        public DbSet<Rooms>? rooms { get; set; }
        public DbSet<Bookings>? bookinggs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rooms>().HasKey(table => new { table.RoomNumber, table.HotelId });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { HotelId= 101,HotelName="Paradise Hotel", Location="Pune",TotalRooms=10,Description="Luxurious hotel with world-class amenities,food,and entertainment",Ratings=4.5 }
                );
            modelBuilder.Entity<Bookings>().HasData(
                        new Bookings { BookingId = 910, BookingDate = new DateTime(2015, 12, 25), HotelId = 102, RoomSize = "Suite", UserId = 1,Price=2970.99}
                               );

            modelBuilder.Entity<Rooms>().HasData(
               new Rooms { RoomNumber = 1011, RoomSize = "Suite", HotelId = 101, IsBooked = true, Price = 1900.99 },
                 new Rooms { RoomNumber = 1012, RoomSize = "Double", HotelId = 101, IsBooked = false, Price = 970.99 },
                    new Rooms { RoomNumber = 1021, RoomSize = "Single", HotelId = 102, IsBooked = true, Price = 570.99 },
                       new Rooms { RoomNumber = 1022, RoomSize = "Suite", HotelId = 102, IsBooked = false, Price = 2970.99 },
                           new Rooms { RoomNumber = 1023, RoomSize = "Luxury", HotelId = 102, IsBooked = false, Price = 1200.99 }
               );
        }
    }
}
