using Microsoft.EntityFrameworkCore.Migrations;

namespace Amingo.Migrations
{
    public partial class ForthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "sex",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "sex",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
