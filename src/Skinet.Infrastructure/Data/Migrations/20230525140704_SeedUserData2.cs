using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skinet.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adbffd99-d818-4011-b5c4-fd444de139e6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "544e35b9-eb9e-4794-9201-e81c1c3c4589", "LIPA@TEST.COM", "LIPA@TEST.COM", "AQAAAAIAAYagAAAAEOnQJvD2FDc/MVKCNViCgbt3wIYTTLXgmHf0xcncBN6XyPBJCg/ZE6rL+AEp6xav8A==", "4e0c41ca-b432-4257-8154-df8f9d5e18be" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adbffd99-d818-4011-b5c4-fd444de139e6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2615bfc5-c5a3-4811-925c-4109ce570e51", null, null, "AQAAAAIAAYagAAAAEPe3Rk87badbvAzuemR1laJ63eYb37JH/3sTNT99LBh4FXWGhFokNuUvPmzvEt0VRQ==", "255ee8ad-1dd6-4c13-b9dd-ac3201355b19" });
        }
    }
}
