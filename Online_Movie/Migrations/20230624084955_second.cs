using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Movie.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20734ca6-31ca-4229-a771-04ec366ba62f", "0dea610f-e1b9-4a7c-aad9-ba20a596ae7a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c8d1541-ce65-45c6-b52f-71437f96ab05", 0, null, "b13c7c80-71ad-4ae2-bed7-4f721466fb55", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAECVHfdKurMsFP2sBBIUdvcQKginpZ/3E7zrhg5rtlQBKVNeaG+C4gwnuadGk6vhWPA==", "1234567890", false, "55fc7df1-020e-4673-a810-d7df3053f190", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "20734ca6-31ca-4229-a771-04ec366ba62f", "6c8d1541-ce65-45c6-b52f-71437f96ab05" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "20734ca6-31ca-4229-a771-04ec366ba62f", "6c8d1541-ce65-45c6-b52f-71437f96ab05" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20734ca6-31ca-4229-a771-04ec366ba62f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c8d1541-ce65-45c6-b52f-71437f96ab05");
        }
    }
}
