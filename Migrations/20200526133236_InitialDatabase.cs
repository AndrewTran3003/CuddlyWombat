using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    MenuID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemMenu",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MenuID = table.Column<string>(nullable: true),
                    ItemID = table.Column<string>(nullable: true),
                    ItemID1 = table.Column<Guid>(nullable: true),
                    MenuID1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemMenu_Items_ItemID1",
                        column: x => x.ItemID1,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemMenu_Menus_MenuID1",
                        column: x => x.MenuID1,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenu_ItemID1",
                table: "ItemMenu",
                column: "ItemID1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenu_MenuID1",
                table: "ItemMenu",
                column: "MenuID1");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MenuID",
                table: "Items",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMenu");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
