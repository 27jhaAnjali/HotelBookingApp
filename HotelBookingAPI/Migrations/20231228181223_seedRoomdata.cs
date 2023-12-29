using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingAPI.Migrations
{
    public partial class seedRoomdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "RoomNumber", "HotelId", "IsBooked", "Price", "RoomSize" },
                values: new object[,]
                {
                    { 1011, 101, true, 1900.99, "Suite" },
                    { 1012, 101, false, 970.99000000000001, "Double" },
                    { 1021, 102, true, 570.99000000000001, "Single" },
                    { 1022, 102, false, 2970.9899999999998, "Suite" },
                    { 1023, 102, false, 1200.99, "Luxury" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "RoomNumber",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "RoomNumber",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "RoomNumber",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "RoomNumber",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "RoomNumber",
                keyValue: 1023);
        }
    }
}
