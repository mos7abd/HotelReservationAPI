using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class isDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Rooms",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "RoomFacility",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Reservation",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "ChekIn",
                table: "Reservation",
                newName: "CheckIn");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Facilities",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Customer",
                newName: "isDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Rooms",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "RoomFacility",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Reservation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Reservation",
                newName: "ChekIn");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Facilities",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Customer",
                newName: "Deleted");
        }
    }
}
