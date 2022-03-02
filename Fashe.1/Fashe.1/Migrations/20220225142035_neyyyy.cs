using Microsoft.EntityFrameworkCore.Migrations;

namespace Fashe._1.Migrations
{
    public partial class neyyyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_CustomUsers_CustomUserId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "CustomUserId",
                table: "Blogs",
                newName: "CUstomUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CustomUserId",
                table: "Blogs",
                newName: "IX_Blogs_CUstomUserId");

            migrationBuilder.AddColumn<string>(
                name: "CUstomUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CUstomUserId",
                table: "Comments",
                column: "CUstomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_CustomUsers_CUstomUserId",
                table: "Blogs",
                column: "CUstomUserId",
                principalTable: "CustomUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CustomUsers_CUstomUserId",
                table: "Comments",
                column: "CUstomUserId",
                principalTable: "CustomUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_CustomUsers_CUstomUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CustomUsers_CUstomUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CUstomUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CUstomUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CUstomUserId",
                table: "Blogs",
                newName: "CustomUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CUstomUserId",
                table: "Blogs",
                newName: "IX_Blogs_CustomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_CustomUsers_CustomUserId",
                table: "Blogs",
                column: "CustomUserId",
                principalTable: "CustomUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
