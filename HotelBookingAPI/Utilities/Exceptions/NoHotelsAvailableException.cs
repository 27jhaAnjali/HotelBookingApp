namespace HotelBookingAPI.Utilities.Exceptions
{
    public class NoHotelsAvailableException:Exception
    {
        public override string Message => "No hotel available,Sorry!!";
    }
}
