using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDecimalPrecisionForAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Customers_CustomerId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_CustomerId",
                table: "Debts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Debts_CustomerId",
                table: "Debts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Customers_CustomerId",
                table: "Debts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
