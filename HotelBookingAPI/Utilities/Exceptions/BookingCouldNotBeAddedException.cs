namespace HotelBookingAPI.Utilities.Exceptions
{
    public class BookingCouldNotBeAddedException:Exception
    {
        public override string Message => "Sorry! Due to some error booking could not be added";
    }
}
