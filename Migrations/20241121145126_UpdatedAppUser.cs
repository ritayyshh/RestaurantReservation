using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ea0953b-61bd-49e3-b2a1-3e5fed70e831");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d4373a7-ec46-4fb8-b4bc-ba2fa70cadd9");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e501a00b-d299-4a29-a677-8b3870e5a2fd", null, "Admin", "ADMIN" },
                    { "f2f221a8-852f-4a53-a646-b64f63069979", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e501a00b-d299-4a29-a677-8b3870e5a2fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2f221a8-852f-4a53-a646-b64f63069979");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ea0953b-61bd-49e3-b2a1-3e5fed70e831", null, "Admin", "ADMIN" },
                    { "7d4373a7-ec46-4fb8-b4bc-ba2fa70cadd9", null, "User", "USER" }
                });
        }
    }
}
