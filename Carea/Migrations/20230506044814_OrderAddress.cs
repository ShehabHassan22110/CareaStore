using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carea.Migrations
{
    public partial class OrderAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "SavedOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "SavedOrders");
        }
    }
}
