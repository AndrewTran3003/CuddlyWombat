using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class UpdateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Items_ItemID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Menus_MenuID",
                table: "OrderMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Orders_OrderID",
                table: "OrderMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenu",
                table: "OrderMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderMenu",
                newName: "OrderMenus");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenu_OrderID",
                table: "OrderMenus",
                newName: "IX_OrderMenus_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenu_MenuID",
                table: "OrderMenus",
                newName: "IX_OrderMenus_MenuID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ItemID",
                table: "OrderItems",
                newName: "IX_OrderItems_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_ItemID",
                table: "OrderItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenus_Menus_MenuID",
                table: "OrderMenus",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenus_Orders_OrderID",
                table: "OrderMenus",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_ItemID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenus_Menus_MenuID",
                table: "OrderMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenus_Orders_OrderID",
                table: "OrderMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderMenus",
                newName: "OrderMenu");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenus_OrderID",
                table: "OrderMenu",
                newName: "IX_OrderMenu_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenus_MenuID",
                table: "OrderMenu",
                newName: "IX_OrderMenu_MenuID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ItemID",
                table: "OrderItem",
                newName: "IX_OrderItem_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenu",
                table: "OrderMenu",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Items_ItemID",
                table: "OrderItem",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderID",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Menus_MenuID",
                table: "OrderMenu",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Orders_OrderID",
                table: "OrderMenu",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
