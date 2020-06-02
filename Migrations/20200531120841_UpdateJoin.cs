using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class UpdateJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenusSold",
                table: "OrderMenus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemsSold",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenusSold",
                table: "OrderMenus");

            migrationBuilder.DropColumn(
                name: "ItemsSold",
                table: "OrderItems");
        }
    }
}
