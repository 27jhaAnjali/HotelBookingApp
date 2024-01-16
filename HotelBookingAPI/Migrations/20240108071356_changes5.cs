using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingAPI.Migrations
{
    public partial class changes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bookinggs",
                keyColumn: "BookingId",
                keyValue: 900);

            migrationBuilder.InsertData(
                table: "bookinggs",
                columns: new[] { "BookingId", "BookingDate", "HotelId", "RoomSize", "UserId" },
                values: new object[] { 910, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, "Suite", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bookinggs",
                keyColumn: "BookingId",
                keyValue: 910);

            migrationBuilder.InsertData(
                table: "bookinggs",
                columns: new[] { "BookingId", "BookingDate", "HotelId", "RoomSize", "UserId" },
                values: new object[] { 900, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, "Suite", 1 });
        }
    }
}
