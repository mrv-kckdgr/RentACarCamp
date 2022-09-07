using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandEntityId",
                        column: x => x.BrandEntityId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "BMW");

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandEntityId", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, 1500m, "", "Series 4" },
                    { 2, null, 1, 1200m, "", "Series 3" },
                    { 3, null, 2, 1000m, "", "A180" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandEntityId",
                table: "Models",
                column: "BrandEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "BMV");
        }
    }
}
