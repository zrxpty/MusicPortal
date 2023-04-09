using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.DAL.Migrations
{
    public partial class mymusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81f8193d-caef-4684-93d9-4144e93c2802");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d308e70-7605-4af0-8db6-6f49a36288a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "814a7195-f936-4b29-a1d4-14076faec4fa", "1be02646-3abc-4e8e-8bab-d3d930f0b511", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1e5a4b1-568d-4acb-a60a-77e10b6ae0b4", "6a96101d-56a1-42e1-a748-8b21ea34cc84", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "814a7195-f936-4b29-a1d4-14076faec4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e5a4b1-568d-4acb-a60a-77e10b6ae0b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d308e70-7605-4af0-8db6-6f49a36288a2", "d622d2c4-a2d9-49fe-8f1e-7750eff6c1c2", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81f8193d-caef-4684-93d9-4144e93c2802", "0b4a88ca-68fa-4241-a773-e56bf3f73667", "User", null });
        }
    }
}
