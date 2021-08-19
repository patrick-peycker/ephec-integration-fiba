using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiba.DAL.Migrations
{
    public partial class MatchModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Round",
                table: "Matches",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "Matches");
        }
    }
}
