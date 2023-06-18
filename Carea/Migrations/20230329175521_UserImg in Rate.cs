using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carea.Migrations
{
    public partial class UserImginRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImg",
                table: "Car_Rate",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImg",
                table: "Car_Rate");
        }
    }
}
