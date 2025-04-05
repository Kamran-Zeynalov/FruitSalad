using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaladBack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFruitImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Fruits",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Fruits");
        }
    }
}
