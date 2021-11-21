using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryControlSystem.Migrations
{
    public partial class ProductDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
                    ProductDiscription = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ProductQuantity = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
