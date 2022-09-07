using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Addmodelbrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandEntityId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_BrandEntityId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "BrandEntityId",
                table: "Models");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_BrandId",
                table: "Models");

            migrationBuilder.AddColumn<int>(
                name: "BrandEntityId",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandEntityId",
                table: "Models",
                column: "BrandEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandEntityId",
                table: "Models",
                column: "BrandEntityId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
