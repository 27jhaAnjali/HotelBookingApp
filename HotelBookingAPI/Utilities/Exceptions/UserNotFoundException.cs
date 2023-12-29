namespace HotelBookingAPI.Utilities.Exceptions
{
    public class UserNotFoundException:Exception
    {
        public override string Message => "User was not found in our Database";
    }
}
