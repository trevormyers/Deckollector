using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deckollector.Migrations
{
    /// <inheritdoc />
    public partial class WishlistDescriptionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WishlistDescription",
                table: "Wishlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WishlistDescription",
                table: "Wishlist");
        }
    }
}
