using Microsoft.EntityFrameworkCore.Migrations;

namespace Fashe._1.Migrations
{
    public partial class xxccvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_CUstomUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CUstomUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CUstomUserId",
                table: "Comments",
                newName: "CustomUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CUstomUserId",
                table: "Comments",
                newName: "IX_Comments_CustomUserId");

            migrationBuilder.RenameColumn(
                name: "CUstomUserId",
                table: "Blogs",
                newName: "CustomUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CUstomUserId",
                table: "Blogs",
                newName: "IX_Blogs_CustomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_CustomUserId",
                table: "Blogs",
                column: "CustomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CustomUserId",
                table: "Comments",
                column: "CustomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_CustomUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CustomUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CustomUserId",
                table: "Comments",
                newName: "CUstomUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomUserId",
                table: "Comments",
                newName: "IX_Comments_CUstomUserId");

            migrationBuilder.RenameColumn(
                name: "CustomUserId",
                table: "Blogs",
                newName: "CUstomUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CustomUserId",
                table: "Blogs",
                newName: "IX_Blogs_CUstomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_CUstomUserId",
                table: "Blogs",
                column: "CUstomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CUstomUserId",
                table: "Comments",
                column: "CUstomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
