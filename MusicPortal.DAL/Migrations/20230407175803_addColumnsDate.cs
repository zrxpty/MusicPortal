using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPortal.DAL.Migrations
{
    public partial class addColumnsDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5be0c77c-ac5c-45b6-84ea-b5c00a7bca03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37917bd-c959-49c2-bc32-12eece98bb6b");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Musics",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d308e70-7605-4af0-8db6-6f49a36288a2", "d622d2c4-a2d9-49fe-8f1e-7750eff6c1c2", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81f8193d-caef-4684-93d9-4144e93c2802", "0b4a88ca-68fa-4241-a773-e56bf3f73667", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81f8193d-caef-4684-93d9-4144e93c2802");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d308e70-7605-4af0-8db6-6f49a36288a2");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Musics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c37917bd-c959-49c2-bc32-12eece98bb6b", "b98a3b6f-1436-424f-9b9c-b831a24c9f6f", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5be0c77c-ac5c-45b6-84ea-b5c00a7bca03", "bdad6af0-f9bd-455f-9f80-e90c116f2853", "User", null });
        }
    }
}
