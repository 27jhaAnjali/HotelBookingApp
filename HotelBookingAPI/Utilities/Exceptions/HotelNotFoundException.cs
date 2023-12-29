namespace HotelBookingAPI.Utilities.Exceptions
{
    public class HotelNotFoundException:Exception
    {
        public override string Message => "Hotel was not found.Sorry!!";
    }
}
