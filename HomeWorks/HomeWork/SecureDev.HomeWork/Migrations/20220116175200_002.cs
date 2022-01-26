using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson1.SQL_Injecrion.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumb",
                table: "Cards");

            migrationBuilder.AddColumn<long>(
                name: "NumbCard",
                table: "Cards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumbCard",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "CardNumb",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
