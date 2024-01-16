namespace HotelBookingAPI.Utilities.Exceptions
{
    public class RoomNotAvailabeException : Exception
    {
        public override string Message => "This room is booked";
    }
}
