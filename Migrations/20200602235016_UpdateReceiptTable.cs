using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class UpdateReceiptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsDetail",
                table: "Receipts");

            migrationBuilder.AddColumn<string>(
                name: "OrderDetail",
                table: "Receipts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Payment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Payment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDetail",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Payment");

            migrationBuilder.AddColumn<string>(
                name: "ItemsDetail",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
