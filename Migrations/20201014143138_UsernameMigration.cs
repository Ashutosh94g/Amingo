using Microsoft.EntityFrameworkCore.Migrations;

namespace Amingo.Migrations
{
    public partial class UsernameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Users");
        }
    }
}
