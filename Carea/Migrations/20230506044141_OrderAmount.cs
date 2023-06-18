using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carea.Migrations
{
    public partial class OrderAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SavedOrders",
                newName: "TAX");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "SavedOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ShippingId",
                table: "SavedOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SavedOrders_ShippingId",
                table: "SavedOrders",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedOrders_Shipping_ShippingId",
                table: "SavedOrders",
                column: "ShippingId",
                principalTable: "Shipping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedOrders_Shipping_ShippingId",
                table: "SavedOrders");

            migrationBuilder.DropIndex(
                name: "IX_SavedOrders_ShippingId",
                table: "SavedOrders");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SavedOrders");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "SavedOrders");

            migrationBuilder.RenameColumn(
                name: "TAX",
                table: "SavedOrders",
                newName: "Status");
        }
    }
}
