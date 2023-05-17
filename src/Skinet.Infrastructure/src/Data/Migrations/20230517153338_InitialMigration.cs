using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Skinet.Infrastructure.src.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeID = table.Column<int>(type: "int", nullable: false),
                    ProductBrandID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandID",
                        column: x => x.ProductBrandID,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Angular" },
                    { 2, "NetCore" },
                    { 3, "VS Code" },
                    { 4, "React" },
                    { 5, "Typescript" },
                    { 6, "Redis" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boards" },
                    { 2, "Hats" },
                    { 3, "Boots" },
                    { 4, "Gloves" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "PictureUrl", "Price", "ProductBrandID", "ProductName", "ProductTypeID" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/sb-ang1.png", 200m, 1, "Angular Speedster Board 2000", 1 },
                    { 2, "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "images/products/sb-ang2.png", 150m, 1, "Green Angular Board 3000", 1 },
                    { 3, "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/sb-core1.png", 180m, 2, "Core Board Speed Rush 3", 1 },
                    { 4, "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/sb-core2.png", 300m, 2, "Net Core Super Board", 1 },
                    { 5, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/sb-react1.png", 250m, 4, "React Board Super Whizzy Fast", 1 },
                    { 6, "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "images/products/sb-ts1.png", 120m, 5, "Typescript Entry Board", 1 },
                    { 7, "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/hat-core1.png", 10m, 2, "Core Blue Hat", 2 },
                    { 8, "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/hat-react1.png", 8m, 4, "Green React Woolen Hat", 2 },
                    { 9, "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/hat-react2.png", 15m, 4, "Purple React Woolen Hat", 2 },
                    { 10, "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "images/products/glove-code1.png", 18m, 3, "Blue Code Gloves", 4 },
                    { 11, "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/glove-code2.png", 15m, 3, "Green Code Gloves", 4 },
                    { 12, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", "images/products/glove-react1.png", 16m, 4, "Purple React Gloves", 4 },
                    { 13, "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/glove-react2.png", 14m, 4, "Green React Gloves", 4 },
                    { 14, "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/boot-redis1.png", 250m, 6, "Redis Red Boots", 3 },
                    { 15, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/boot-core2.png", 189.99m, 2, "Core Red Boots", 3 },
                    { 16, "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/boot-core1.png", 199.99m, 2, "Core Purple Boots", 3 },
                    { 17, "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "images/products/boot-ang2.png", 150m, 1, "Angular Purple Boots", 3 },
                    { 18, "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/boot-ang1.png", 180m, 1, "Angular Blue Boots", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandID",
                table: "Products",
                column: "ProductBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeID",
                table: "Products",
                column: "ProductTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
