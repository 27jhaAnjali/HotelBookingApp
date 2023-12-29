namespace HotelBookingAPI.Utilities.Exceptions
{
    public class NoUserInTheDataBaseException:Exception
    {
        public override string Message => "No users were found in the database.";
    }
}
