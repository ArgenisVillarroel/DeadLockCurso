using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountinManager.Data.Migrations
{
    public partial class AddIndexUniqueAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AccountTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_Code",
                table: "AccountTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountTypes_Code",
                table: "AccountTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AccountTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
