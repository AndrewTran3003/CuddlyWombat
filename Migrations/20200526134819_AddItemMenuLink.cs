using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class AddItemMenuLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMenu_Items_ItemID1",
                table: "ItemMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMenu_Menus_MenuID1",
                table: "ItemMenu");

            migrationBuilder.DropIndex(
                name: "IX_ItemMenu_ItemID1",
                table: "ItemMenu");

            migrationBuilder.DropIndex(
                name: "IX_ItemMenu_MenuID1",
                table: "ItemMenu");

            migrationBuilder.DropColumn(
                name: "ItemID1",
                table: "ItemMenu");

            migrationBuilder.DropColumn(
                name: "MenuID1",
                table: "ItemMenu");

            migrationBuilder.AlterColumn<Guid>(
                name: "MenuID",
                table: "ItemMenu",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemID",
                table: "ItemMenu",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenu_ItemID",
                table: "ItemMenu",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenu_MenuID",
                table: "ItemMenu",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMenu_Items_ItemID",
                table: "ItemMenu",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMenu_Menus_MenuID",
                table: "ItemMenu",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMenu_Items_ItemID",
                table: "ItemMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMenu_Menus_MenuID",
                table: "ItemMenu");

            migrationBuilder.DropIndex(
                name: "IX_ItemMenu_ItemID",
                table: "ItemMenu");

            migrationBuilder.DropIndex(
                name: "IX_ItemMenu_MenuID",
                table: "ItemMenu");

            migrationBuilder.AlterColumn<string>(
                name: "MenuID",
                table: "ItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "ItemID",
                table: "ItemMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemID1",
                table: "ItemMenu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MenuID1",
                table: "ItemMenu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenu_ItemID1",
                table: "ItemMenu",
                column: "ItemID1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenu_MenuID1",
                table: "ItemMenu",
                column: "MenuID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMenu_Items_ItemID1",
                table: "ItemMenu",
                column: "ItemID1",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMenu_Menus_MenuID1",
                table: "ItemMenu",
                column: "MenuID1",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
