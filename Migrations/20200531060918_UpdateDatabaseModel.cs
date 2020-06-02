using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class UpdateDatabaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Menus_MenuID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Order_OrderID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Order_OrderID",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Order_OrderID",
                table: "OrderMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_OrderID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Items_MenuID",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "MenuID",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Menus",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderID",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Orders_OrderID",
                table: "OrderMenu",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Orders_OrderID",
                table: "Payment",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Orders_OrderID",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Orders_OrderID",
                table: "OrderMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Orders_OrderID",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Menus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MenuID",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MenuID",
                table: "Items",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Menus_MenuID",
                table: "Items",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Order_OrderID",
                table: "Items",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Order_OrderID",
                table: "Menus",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderID",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Order_OrderID",
                table: "OrderMenu",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_OrderID",
                table: "Payment",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
