using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Debts");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Debts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Debts");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Debts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
