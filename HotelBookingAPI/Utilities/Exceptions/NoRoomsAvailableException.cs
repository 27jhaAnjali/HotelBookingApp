namespace HotelBookingAPI.Utilities.Exceptions
{
    public class NoRoomsAvailableException:Exception
    {
        public override string Message => "No rooms exits";
    }
}
