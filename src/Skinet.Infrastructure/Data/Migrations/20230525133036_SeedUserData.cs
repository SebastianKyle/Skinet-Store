using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skinet.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "adbffd99-d818-4011-b5c4-fd444de139e6", 0, "2615bfc5-c5a3-4811-925c-4109ce570e51", "Lipa", "lipa@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEPe3Rk87badbvAzuemR1laJ63eYb37JH/3sTNT99LBh4FXWGhFokNuUvPmzvEt0VRQ==", null, false, "255ee8ad-1dd6-4c13-b9dd-ac3201355b19", false, "lipa@test.com" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AppUserId", "City", "FirstName", "LastName", "State", "Street", "ZipCode" },
                values: new object[] { 1, "adbffd99-d818-4011-b5c4-fd444de139e6", "NewYork", "Dua", "Lipa", "NY", "10 Green Street", "90210" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adbffd99-d818-4011-b5c4-fd444de139e6");
        }
    }
}
