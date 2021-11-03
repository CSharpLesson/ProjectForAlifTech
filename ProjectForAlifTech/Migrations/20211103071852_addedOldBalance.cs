using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronWallet.Migrations
{
    public partial class addedOldBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "old_balance",
                table: "user_account",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "old_balance",
                table: "user_account");
        }
    }
}
