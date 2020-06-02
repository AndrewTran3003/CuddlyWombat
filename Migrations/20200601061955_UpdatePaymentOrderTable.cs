using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class UpdatePaymentOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Orders_OrderID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_OrderID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Payment");

            migrationBuilder.CreateTable(
                name: "PaymentOrder",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PaymentID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_OrderID",
                table: "PaymentOrder",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_PaymentID",
                table: "PaymentOrder",
                column: "PaymentID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                table: "Payment",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Orders_OrderID",
                table: "Payment",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
