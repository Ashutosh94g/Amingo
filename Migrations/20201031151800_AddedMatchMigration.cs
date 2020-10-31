using Microsoft.EntityFrameworkCore.Migrations;

namespace Amingo.Migrations
{
    public partial class AddedMatchMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Match",
                table: "Likes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Match",
                table: "Likes");
        }
    }
}
