using Microsoft.EntityFrameworkCore.Migrations;

namespace Fashe._1.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutContent",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutContent",
                table: "Settings",
                type: "ntext",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutTitle",
                table: "Settings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Settings",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
