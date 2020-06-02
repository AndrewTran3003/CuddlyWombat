using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class AddOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AmountDue = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Employee = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ItemID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderMenu",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MenuID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderMenu_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenu_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Method = table.Column<string>(nullable: true),
                    OrderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_OrderID",
                table: "Menus",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderID",
                table: "Items",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemID",
                table: "OrderItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenu_MenuID",
                table: "OrderMenu",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenu_OrderID",
                table: "OrderMenu",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                table: "Payment",
                column: "OrderID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Order_OrderID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Order_OrderID",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderMenu");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Order");

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
    }
}
