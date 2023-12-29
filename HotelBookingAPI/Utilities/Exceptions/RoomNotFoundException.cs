namespace HotelBookingAPI.Utilities.Exceptions
{
    public class RoomNotFoundException:Exception
    {
        public override string Message => "This room does not exits";
    }
}
