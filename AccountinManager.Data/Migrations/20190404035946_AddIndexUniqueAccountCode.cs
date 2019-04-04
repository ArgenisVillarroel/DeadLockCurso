using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountinManager.Data.Migrations
{
    public partial class AddIndexUniqueAccountCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Code",
                table: "Accounts",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Code",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
