using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookMarks.Migrations
{
    public partial class UpdateBmModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateСreation",
                table: "BookMarks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateСreation",
                table: "BookMarks");
        }
    }
}
