using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carea.Migrations
{
    public partial class CreateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedOrders");

            migrationBuilder.CreateTable(
                name: "CreateOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    ShippingId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SevedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TAX = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreateOrder_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreateOrder_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreateOrder_Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreateOrder_ApplicationUserId",
                table: "CreateOrder",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreateOrder_CarsId",
                table: "CreateOrder",
                column: "CarsId");

            migrationBuilder.CreateIndex(
                name: "IX_CreateOrder_ShippingId",
                table: "CreateOrder",
                column: "ShippingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateOrder");

            migrationBuilder.CreateTable(
                name: "SavedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    ShippingId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SevedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TAX = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedOrders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedOrders_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedOrders_Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedOrders_ApplicationUserId",
                table: "SavedOrders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedOrders_CarsId",
                table: "SavedOrders",
                column: "CarsId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedOrders_ShippingId",
                table: "SavedOrders",
                column: "ShippingId");
        }
    }
}
