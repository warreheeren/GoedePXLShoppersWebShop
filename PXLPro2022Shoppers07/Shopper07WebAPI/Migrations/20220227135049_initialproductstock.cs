using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopper07WebAPI.Migrations
{
    public partial class initialproductstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStocks",
                columns: table => new
                {
                    ProductStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStocks", x => x.ProductStockId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStocks");
        }
    }
}
