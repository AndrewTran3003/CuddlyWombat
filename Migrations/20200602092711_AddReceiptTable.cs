using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombat.Migrations
{
    public partial class AddReceiptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    MerchantID = table.Column<string>(nullable: true),
                    ItemsDetail = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentReceipt",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ReceiptID = table.Column<Guid>(nullable: false),
                    PaymentID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReceipt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentReceipt_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentReceipt_Receipts_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "Receipts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipt_PaymentID",
                table: "PaymentReceipt",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipt_ReceiptID",
                table: "PaymentReceipt",
                column: "ReceiptID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentReceipt");

            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
