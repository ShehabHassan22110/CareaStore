using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carea.Migrations
{
    public partial class carprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Car_Price",
                table: "Cars",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Car_Rate",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Car_Rate_UserId",
                table: "Car_Rate",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Rate_AspNetUsers_UserId",
                table: "Car_Rate",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Rate_AspNetUsers_UserId",
                table: "Car_Rate");

            migrationBuilder.DropIndex(
                name: "IX_Car_Rate_UserId",
                table: "Car_Rate");

            migrationBuilder.AlterColumn<string>(
                name: "Car_Price",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Car_Rate",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
