namespace HotelBookingAPI.Utilities.Exceptions
{
    public class BookingNotFoundException:Exception
    {
        public override string Message => "Booking cannot be found.sorry";
    }
}
