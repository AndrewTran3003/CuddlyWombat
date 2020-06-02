using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class UpdateOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Orders_OrderID",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_OrderID",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_OrderID",
                table: "Menus",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderID",
                table: "Items",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrderID",
                table: "Items",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Orders_OrderID",
                table: "Menus",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
