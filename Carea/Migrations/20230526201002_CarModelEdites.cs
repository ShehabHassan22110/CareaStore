using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carea.Migrations
{
    public partial class CarModelEdites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Airbags",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Car_FuelType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Cylinders",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Doors",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Drive_Wheels",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Engine_volume",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Gear_Box_Type",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Leather_Interior",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Levy",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Turbo",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Wheel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airbags",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Car_FuelType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Cylinders",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Doors",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Drive_Wheels",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Engine_volume",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Gear_Box_Type",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Leather_Interior",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Levy",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Turbo",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Wheel",
                table: "Cars");
        }
    }
}
