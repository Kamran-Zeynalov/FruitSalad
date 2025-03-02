using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaladBack.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FruitImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FruitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FruitImage_Fruits_FruitId",
                        column: x => x.FruitId,
                        principalTable: "Fruits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaladImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FruitSaladId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaladImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaladImage_FruitSalads_FruitSaladId",
                        column: x => x.FruitSaladId,
                        principalTable: "FruitSalads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FruitImage_FruitId",
                table: "FruitImage",
                column: "FruitId");

            migrationBuilder.CreateIndex(
                name: "IX_SaladImage_FruitSaladId",
                table: "SaladImage",
                column: "FruitSaladId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FruitImage");

            migrationBuilder.DropTable(
                name: "SaladImage");
        }
    }
}
