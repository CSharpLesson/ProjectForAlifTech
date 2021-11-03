using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronWallet.Migrations
{
    public partial class changeAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "account_id",
                table: "account_history",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_account_history_account_id",
                table: "account_history",
                column: "account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_account_history_user_account_account_id",
                table: "account_history",
                column: "account_id",
                principalTable: "user_account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_history_user_account_account_id",
                table: "account_history");

            migrationBuilder.DropIndex(
                name: "IX_account_history_account_id",
                table: "account_history");

            migrationBuilder.DropColumn(
                name: "account_id",
                table: "account_history");
        }
    }
}
