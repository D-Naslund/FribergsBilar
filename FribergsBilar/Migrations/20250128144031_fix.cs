using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergsBilar.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId2",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId2",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId2",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId2",
                table: "Bookings",
                column: "UserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId2",
                table: "Bookings",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
