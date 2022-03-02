using Microsoft.EntityFrameworkCore.Migrations;

namespace Fashe._1.Migrations
{
    public partial class ppppppppppppppppppppp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeToColorToProducts_ColorToProducts_ColorToProductId",
                table: "SizeToColorToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeToColorToProducts_Sizes_SizeId",
                table: "SizeToColorToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeToColorToProducts",
                table: "SizeToColorToProducts");

            migrationBuilder.RenameTable(
                name: "SizeToColorToProducts",
                newName: "SizeColorToProducts");

            migrationBuilder.RenameIndex(
                name: "IX_SizeToColorToProducts_SizeId",
                table: "SizeColorToProducts",
                newName: "IX_SizeColorToProducts_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_SizeToColorToProducts_ColorToProductId",
                table: "SizeColorToProducts",
                newName: "IX_SizeColorToProducts_ColorToProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeColorToProducts",
                table: "SizeColorToProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeColorToProducts_ColorToProducts_ColorToProductId",
                table: "SizeColorToProducts",
                column: "ColorToProductId",
                principalTable: "ColorToProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeColorToProducts_Sizes_SizeId",
                table: "SizeColorToProducts",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeColorToProducts_ColorToProducts_ColorToProductId",
                table: "SizeColorToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeColorToProducts_Sizes_SizeId",
                table: "SizeColorToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeColorToProducts",
                table: "SizeColorToProducts");

            migrationBuilder.RenameTable(
                name: "SizeColorToProducts",
                newName: "SizeToColorToProducts");

            migrationBuilder.RenameIndex(
                name: "IX_SizeColorToProducts_SizeId",
                table: "SizeToColorToProducts",
                newName: "IX_SizeToColorToProducts_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_SizeColorToProducts_ColorToProductId",
                table: "SizeToColorToProducts",
                newName: "IX_SizeToColorToProducts_ColorToProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeToColorToProducts",
                table: "SizeToColorToProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeToColorToProducts_ColorToProducts_ColorToProductId",
                table: "SizeToColorToProducts",
                column: "ColorToProductId",
                principalTable: "ColorToProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeToColorToProducts_Sizes_SizeId",
                table: "SizeToColorToProducts",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
