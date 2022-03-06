using Microsoft.EntityFrameworkCore.Migrations;

namespace PXLPro2022Shoppers07.Migrations
{
    public partial class favoriteproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteProductId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavoriteProductId",
                table: "Products",
                column: "FavoriteProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Favorites_FavoriteProductId",
                table: "Products",
                column: "FavoriteProductId",
                principalTable: "Favorites",
                principalColumn: "FavoriteProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Favorites_FavoriteProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Products_FavoriteProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FavoriteProductId",
                table: "Products");
        }
    }
}
