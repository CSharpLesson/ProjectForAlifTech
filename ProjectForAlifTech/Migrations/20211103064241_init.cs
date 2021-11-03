using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronWallet.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "user_account",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "user_account",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Click.uz");

            migrationBuilder.UpdateData(
                table: "user_account",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Apelsin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "user_account");
        }
    }
}
