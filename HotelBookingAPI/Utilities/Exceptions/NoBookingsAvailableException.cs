namespace HotelBookingAPI.Utilities.Exceptions
{
    public class NoBookingsAvailableException:Exception
    {
        public override string Message => "No bookings right now";
    }
}
