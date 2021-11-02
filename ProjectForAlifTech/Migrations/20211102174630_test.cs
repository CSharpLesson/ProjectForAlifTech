using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ElectronWallet.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    xuser_id = table.Column<string>(name: "x-user_id", type: "text", nullable: true),
                    xdigest = table.Column<string>(name: "x-digest", type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "account_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_history_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_account",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_account", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_account_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "is_active", "phone", "x-digest", "x-user_id" },
                values: new object[,]
                {
                    { 1, true, null, "Y2U4YWE2YTRjYWRjYTk1YjIzZmNjY2M5NWM1MWI4NWNiODEzNDM0ZQ==", "ibrohim_ii" },
                    { 2, false, null, "NDM2YjUxNjY1ZGU0YTFkMzYwMzA0ZjRhOTRmNjM1NDkzMjc3ZWY2Nw==", "akrom_ia" }
                });

            migrationBuilder.InsertData(
                table: "user_account",
                columns: new[] { "id", "balance", "user_id" },
                values: new object[,]
                {
                    { 1, 50000m, 1 },
                    { 2, 6000m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_history_user_id",
                table: "account_history",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_account_user_id",
                table: "user_account",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_history");

            migrationBuilder.DropTable(
                name: "user_account");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
