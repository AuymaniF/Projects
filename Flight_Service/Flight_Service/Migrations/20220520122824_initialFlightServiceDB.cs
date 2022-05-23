using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Service.Migrations
{
    public partial class initialFlightServiceDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Flights_flightId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Passengers_PassengerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_FlightId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PassengerId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "flightId",
                table: "Bookings",
                newName: "FlightId");

            migrationBuilder.RenameColumn(
                name: "FlightNumber",
                table: "Bookings",
                newName: "ReservationNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_flightId",
                table: "Bookings",
                newName: "IX_Bookings_FlightId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PassengerId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PassengerId",
                table: "Bookings",
                column: "PassengerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bookings_PassengerId1",
            //    table: "Bookings",
            //    column: "PassengerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Passengers_PassengerId",
                table: "Bookings",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Bookings_Passengers_PassengerId1",
            //    table: "Bookings",
            //    column: "PassengerId",
            //    principalTable: "Passengers",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Passengers_PassengerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Passengers_PassengerId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PassengerId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PassengerId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengerId1",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Passengers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Bookings",
                newName: "flightId");

            migrationBuilder.RenameColumn(
                name: "ReservationNumber",
                table: "Bookings",
                newName: "FlightNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                newName: "IX_Bookings_flightId");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Passengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_FlightId",
                table: "Passengers",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PassengerId",
                table: "Bookings",
                column: "PassengerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Flights_flightId",
                table: "Bookings",
                column: "flightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Passengers_PassengerId",
                table: "Bookings",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Flights_FlightId",
                table: "Passengers",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
