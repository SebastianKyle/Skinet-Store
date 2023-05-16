using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Skinet.Infrastructure.Data.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBrandID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    { new Guid("04dc1a38-bc24-4dbf-9c44-0f22b01ac3ac"), "Angular" },
                    { new Guid("0b03373d-cbf8-4f23-9f0c-b84c2d4a4b1a"), "Redis" },
                    { new Guid("21c5894e-72f8-4ab7-ab08-cf7f2ee4b863"), "React" },
                    { new Guid("4b86e05b-2152-440b-b946-22e429e9758d"), "NetCore" },
                    { new Guid("e595c11b-fc76-4985-90ab-5e455550dece"), "Typescript" },
                    { new Guid("fc267da2-0c5d-4609-911a-96ada3b5451f"), "VS Code" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0a6cfad6-ea3b-481f-a773-458bee602086"), "Boots" },
                    { new Guid("0b266b88-dce6-4f2e-bf86-f9a6e0a5949f"), "Boards" },
                    { new Guid("a0a9db25-63fd-4ac9-ad98-0b8853042aa7"), "Hats" },
                    { new Guid("d4481d8b-9238-4653-bb77-1b6cd13a2b9d"), "Gloves" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "PictureUrl", "Price", "ProductBrandID", "ProductName", "ProductTypeID" },
                values: new object[,]
                {
                    { new Guid("01d034a3-bf1b-49a5-b114-8faed06054e2"), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/sb-core1.png", 180m, new Guid("4b86e05b-2152-440b-b946-22e429e9758d"), "Core Board Speed Rush 3", new Guid("0b266b88-dce6-4f2e-bf86-f9a6e0a5949f") },
                    { new Guid("1e05e91e-12e4-4718-8c38-fcadc046b221"), "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/hat-react2.png", 15m, new Guid("21c5894e-72f8-4ab7-ab08-cf7f2ee4b863"), "Purple React Woolen Hat", new Guid("a0a9db25-63fd-4ac9-ad98-0b8853042aa7") },
                    { new Guid("2ba96895-9187-415b-978d-ce14981c1442"), "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/hat-core1.png", 10m, new Guid("4b86e05b-2152-440b-b946-22e429e9758d"), "Core Blue Hat", new Guid("a0a9db25-63fd-4ac9-ad98-0b8853042aa7") },
                    { new Guid("337748c4-071c-475d-8c06-4da68ae08283"), "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "images/products/sb-ts1.png", 120m, new Guid("e595c11b-fc76-4985-90ab-5e455550dece"), "Typescript Entry Board", new Guid("0b266b88-dce6-4f2e-bf86-f9a6e0a5949f") },
                    { new Guid("4df4b3fe-7ca4-4043-9a0e-706b564d1bc4"), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", "images/products/glove-react1.png", 16m, new Guid("21c5894e-72f8-4ab7-ab08-cf7f2ee4b863"), "Purple React Gloves", new Guid("d4481d8b-9238-4653-bb77-1b6cd13a2b9d") },
                    { new Guid("62aafb98-79cb-49c2-9d33-db9227ab2ec4"), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/sb-ang1.png", 200m, new Guid("04dc1a38-bc24-4dbf-9c44-0f22b01ac3ac"), "Angular Speedster Board 2000", new Guid("0b266b88-dce6-4f2e-bf86-f9a6e0a5949f") },
                    { new Guid("6c179ac9-fc79-4353-ae64-a814febee317"), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/boot-core2.png", 189.99m, new Guid("4b86e05b-2152-440b-b946-22e429e9758d"), "Core Red Boots", new Guid("0a6cfad6-ea3b-481f-a773-458bee602086") },
                    { new Guid("6dc970ce-439a-4da8-8901-d76b06688e7c"), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/boot-redis1.png", 250m, new Guid("0b03373d-cbf8-4f23-9f0c-b84c2d4a4b1a"), "Redis Red Boots", new Guid("0a6cfad6-ea3b-481f-a773-458bee602086") },
                    { new Guid("71961f22-4acc-4dc9-8309-5bcf074ed707"), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/sb-core2.png", 300m, new Guid("4b86e05b-2152-440b-b946-22e429e9758d"), "Net Core Super Board", new Guid("0b266b88-dce6-4f2e-bf86-f9a6e0a5949f") },
                    { new Guid("86cda00d-9d97-46ea-bbc7-43dc29e0d76c"), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/hat-react1.png", 8m, new Guid("21c5894e-72f8-4ab7-ab08-cf7f2ee4b863"), "Green React Woolen Hat", new Guid("a0a9db25-63fd-4ac9-ad98-0b8853042aa7") },
                    { new Guid("95383841-5340-48f3-81d6-7847039792e1"), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "images/products/sb-ang2.png", 150m, new Guid("04dc1a38-bc24-4dbf-9c44-0f22b01ac3ac"), "Green Angular Board 3000", new Guid("0b266b88-dce6-4f2e-bf86-f9a6e0a5949f") },
                    { new Guid("a84e1159-365b-49f1-99e4-818f16879166"), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "images/products/boot-ang1.png", 180m, new Guid("04dc1a38-bc24-4dbf-9c44-0f22b01ac3ac"), "Angular Blue Boots", new Guid("0a6cfad6-ea3b-481f-a773-458bee602086") },
                    { new Guid("aec70461-2f65-43e8-adc3-b86d84eec0ec"), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "images/products/sb-react1.png", 250m, new Guid("21c5894e-72f8-4ab7-ab08-cf7f2ee4b863"), "React Board Super Whizzy Fast", new Guid("0b266b88-dce6-4f2e-bf86-f9a6e0a5949f") },
                    { new Guid("b351da0a-1399-4c1a-8f2f-4a0487116b7e"), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "images/products/glove-code1.png", 18m, new Guid("fc267da2-0c5d-4609-911a-96ada3b5451f"), "Blue Code Gloves", new Guid("d4481d8b-9238-4653-bb77-1b6cd13a2b9d") },
                    { new Guid("c09f0052-3ff9-402e-83e8-83c4f8b59edf"), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/glove-code2.png", 15m, new Guid("fc267da2-0c5d-4609-911a-96ada3b5451f"), "Green Code Gloves", new Guid("d4481d8b-9238-4653-bb77-1b6cd13a2b9d") },
                    { new Guid("c542c49a-c793-40ff-bbc5-3223334d5b11"), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/glove-react2.png", 14m, new Guid("21c5894e-72f8-4ab7-ab08-cf7f2ee4b863"), "Green React Gloves", new Guid("d4481d8b-9238-4653-bb77-1b6cd13a2b9d") },
                    { new Guid("c5b2627f-1bce-4f5f-98ad-a4cdc47fbb65"), "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "images/products/boot-core1.png", 199.99m, new Guid("4b86e05b-2152-440b-b946-22e429e9758d"), "Core Purple Boots", new Guid("0a6cfad6-ea3b-481f-a773-458bee602086") },
                    { new Guid("dbc12ed7-11c1-42ca-970c-db9d62234319"), "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "images/products/boot-ang2.png", 150m, new Guid("04dc1a38-bc24-4dbf-9c44-0f22b01ac3ac"), "Angular Purple Boots", new Guid("0a6cfad6-ea3b-481f-a773-458bee602086") }
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
