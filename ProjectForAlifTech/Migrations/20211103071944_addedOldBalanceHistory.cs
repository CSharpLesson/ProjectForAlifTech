using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronWallet.Migrations
{
    public partial class addedOldBalanceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "old_balance",
                table: "user_account");

            migrationBuilder.AddColumn<decimal>(
                name: "old_balance",
                table: "account_history",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "old_balance",
                table: "account_history");

            migrationBuilder.AddColumn<decimal>(
                name: "old_balance",
                table: "user_account",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
