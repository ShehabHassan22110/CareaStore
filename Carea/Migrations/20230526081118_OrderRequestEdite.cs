using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carea.Migrations
{
    public partial class OrderRequestEdite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "Car_Rate");

            migrationBuilder.DropColumn(
                name: "UserImg",
                table: "Car_Rate");

            migrationBuilder.AlterColumn<int>(
                name: "Statues",
                table: "OrderRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Statues",
                table: "OrderRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "Car_Rate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserImg",
                table: "Car_Rate",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
