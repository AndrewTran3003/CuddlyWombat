using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class UpdateMenuModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Order",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderStartTime",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderType",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Menus",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderStartTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Menus");
        }
    }
}
