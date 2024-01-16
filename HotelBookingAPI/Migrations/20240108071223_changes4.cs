using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingAPI.Migrations
{
    public partial class changes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingg_hotels_HotelId",
                table: "bookingg");

            migrationBuilder.DropForeignKey(
                name: "FK_bookingg_users_UserId",
                table: "bookingg");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookingg",
                table: "bookingg");

            migrationBuilder.RenameTable(
                name: "bookingg",
                newName: "bookinggs");

            migrationBuilder.RenameIndex(
                name: "IX_bookingg_UserId",
                table: "bookinggs",
                newName: "IX_bookinggs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bookingg_HotelId",
                table: "bookinggs",
                newName: "IX_bookinggs_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookinggs",
                table: "bookinggs",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookinggs_hotels_HotelId",
                table: "bookinggs",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookinggs_users_UserId",
                table: "bookinggs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookinggs_hotels_HotelId",
                table: "bookinggs");

            migrationBuilder.DropForeignKey(
                name: "FK_bookinggs_users_UserId",
                table: "bookinggs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookinggs",
                table: "bookinggs");

            migrationBuilder.RenameTable(
                name: "bookinggs",
                newName: "bookingg");

            migrationBuilder.RenameIndex(
                name: "IX_bookinggs_UserId",
                table: "bookingg",
                newName: "IX_bookingg_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bookinggs_HotelId",
                table: "bookingg",
                newName: "IX_bookingg_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookingg",
                table: "bookingg",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingg_hotels_HotelId",
                table: "bookingg",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookingg_users_UserId",
                table: "bookingg",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
