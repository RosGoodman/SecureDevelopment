using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson1.SQL_Injecrion.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Cards",
                newName: "CardOwner");

            migrationBuilder.AddColumn<int>(
                name: "CVV_CVC",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Validity",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV_CVC",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Validity",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "CardOwner",
                table: "Cards",
                newName: "SecondName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
