using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicles.API.Migrations
{
    public partial class codigounique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleTypes_Description",
                table: "VehicleTypes");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Description",
                table: "VehicleTypes",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleTypes_Description",
                table: "VehicleTypes");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Description",
                table: "VehicleTypes",
                column: "Description");
        }
    }
}
