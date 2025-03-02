using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaladBack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSizeAndFruitSaladRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FruitSaladId",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_FruitSaladId",
                table: "Sizes",
                column: "FruitSaladId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_FruitSalads_FruitSaladId",
                table: "Sizes",
                column: "FruitSaladId",
                principalTable: "FruitSalads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_FruitSalads_FruitSaladId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_FruitSaladId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "FruitSaladId",
                table: "Sizes");
        }
    }
}
