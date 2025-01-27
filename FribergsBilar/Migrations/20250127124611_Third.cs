using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergsBilar.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_carId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "carId",
                table: "Bookings",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_carId",
                table: "Bookings",
                newName: "IX_Bookings_CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_CarId",
                table: "Bookings",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_CarId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Bookings",
                newName: "carId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                newName: "IX_Bookings_carId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_carId",
                table: "Bookings",
                column: "carId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
